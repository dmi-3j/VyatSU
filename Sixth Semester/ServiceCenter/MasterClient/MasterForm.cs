using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using Grpc.Net.Client;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using ServiceCenter;

namespace MasterClient
{
    public partial class MasterForm : Form
    {
        private OrdersService.OrdersServiceClient _ordersClient;
        private List<Part> _selectedParts = new List<Part>();
        private bool flagEndOrders = false;
        private const string DateFormat = "dd.MM.yyyy";

        private Master _authenticatedMaster;
        private IConnection _connection;
        private IModel _channel;
        private BindingList<OrderRequest> _queueOrders = new BindingList<OrderRequest>();
        private Dictionary<string, (OrderRequest order, ulong deliveryTag)> _pendingOrders = new Dictionary<string, (OrderRequest order, ulong deliveryTag)>();

        public MasterForm(Master authenticatedMaster, OrdersService.OrdersServiceClient ordersClient = null)
        {
            InitializeComponent();
            Log.Information("MasterForm initialization started for master: {MasterName}", authenticatedMaster.FullName);

            try
            {
                _authenticatedMaster = authenticatedMaster;
                InitializeGrpcClient();
                LoadOrders();
                InitComboBoxes();

                this.KeyPreview = true;
                this.KeyUp += MasterForm_KeyUp;
                this.KeyDown += MasterForm_KeyDown;
                dgvOrders.ContextMenuStrip = dgvContextMenu;
                btnUpdateOrder.Click += BtnUpdateOrder_Click;
                dgvOrders.CellClick += DgvOrders_CellClick;

                Log.Information("MasterForm initialized successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "MasterForm initialization failed");
                throw;
            }
        }

        private void InitializeGrpcClient()
        {
            Log.Debug("Initializing gRPC client");
            try
            {
                var grpcAddress = Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS");

                if (string.IsNullOrWhiteSpace(grpcAddress))
                {
                    grpcAddress = "http://localhost:50051"; // или нужный тебе адрес по умолчанию
                    Log.Warning("Environment variable GRPC_SERVER_ADDRESS not set, using default: {Address}", grpcAddress);
                }

                var channel = GrpcChannel.ForAddress(grpcAddress);
                _ordersClient = new OrdersService.OrdersServiceClient(channel);
                Log.Information("gRPC client initialized successfully with address {Address}", grpcAddress);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to initialize gRPC client");
                throw;
            }
        }

        public async Task LoadOrders()
        {
            Log.Debug("Loading orders for master: {MasterName}", _authenticatedMaster.FullName);
            ClearInputFields();

            try
            {
                string specialization = _authenticatedMaster.Specialization;
                var request = new GetOrdersRequest
                {
                    StatusFilter = flagEndOrders ? "Готов к выдаче" : ""
                };

                var ordersResponse = await _ordersClient.GetOrdersAsync(request);
                Log.Debug("Received {Count} orders from server", ordersResponse.Orders.Count);

                var orders = ordersResponse.Orders
                    .Where(o => o.ResponsibleMaster.Equals(_authenticatedMaster.FullName))
                    .Select(order => new
                    {
                        order.OrderId,
                        order.CustomerName,
                        order.PhoneNumber,
                        order.DeviceType,
                        order.DeviceModel,
                        order.RepairType,
                        order.Description,
                        order.Status,
                        OrderDate = DateTime.TryParseExact(order.OrderDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate)
                            ? parsedDate.ToString(DateFormat)
                            : "Неверная дата",
                        Parts = string.Join(", ", order.Parts.Select(p => $"{p.Name} (x{p.Quantity})")),
                        order.WarehouseRequestStatus,
                        order.Price,
                        // Добавляем сюда для теста
                        order.ResponsibleMaster
                    })
                    .Cast<object>()
                    .ToList();

                if (orders.Count == 0)
                {
                    Log.Information("No orders found for master");
                    ShowNotification("Нет заказов для отображения.", "Предупреждение");
                    dgvOrders.DataSource = null;
                    return;
                }

                dgvOrders.DataSource = orders;
                SetColumnHeaders();
                dgvOrders.ClearSelection();
                Log.Information("Displaying {Count} orders", orders.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load orders");
                ShowNotification($"Ошибка при загрузке заказов: {ex.Message}\n{ex.StackTrace}", "Ошибка");
            }
        }

        private void ShowNotification(string message, string type)
        {

            Log.Debug("Showing notification: {Type} - {Message}", type, message); notifyIcon1.BalloonTipText = message;

            if (type.Equals("Ошибка"))
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            }
            else if (type.Equals("Предупреждение"))
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
            }
            else
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            }
            notifyIcon1.ShowBalloonTip(3000);
        }

        private void SetColumnHeaders()
        {
            var headers = new[] {
                "Имя клиента", "Телефон", "Тип устройства", "Модель устройства",
                "Тип ремонта", "Описание", "Статус", "Дата заказа", "Комплектующие", "Заявка на склад"
            };

            for (int i = 0; i < headers.Length; i++)
                dgvOrders.Columns[i + 1].HeaderText = headers[i];

            dgvOrders.Columns["OrderId"].Visible = false;
            dgvOrders.Columns["Price"].Visible = false;
           
        }


        private void InitComboBoxes()
        {
            cboStatus.Items.AddRange(new[] {"В работе", "Готов к выдаче", "Отменён" });
            cboParts.Items.AddRange(new[] { "Дисплей", "Аккумулятор", "Клавиатура", "Материнская плата" });
            dgvOrders.ContextMenuStrip = dgvContextMenu;
            this.KeyPreview = true;
            this.KeyUp += MasterForm_KeyUp;
            this.KeyDown += MasterForm_KeyDown;
        }

        private void ClearInputFields()
        {
            txtDescription.Clear();
            cboStatus.SelectedIndex = -1;
            cboParts.SelectedIndex = -1;
            nudPartQuantity.Value = 1;
            _selectedParts.Clear();
            dgvParts.DataSource = null;
        }

        public void BtnAddPart_Click(object sender, EventArgs e)
        {
            Log.Debug("Attempting to add part to order");

            if (cboParts.SelectedIndex == -1)
            {
                Log.Warning("No part type selected");
                ShowNotification("Выберите комплектующее.", "Предупреждение");
                return;
            }

            string partModel = txtPartModel.Text.Trim();

            if (string.IsNullOrEmpty(partModel))
            {
                Log.Warning("Part model not specified");
                ShowNotification("Введите модель комплектующего.", "Предупреждение");
                return;
            }

            if (string.IsNullOrEmpty(cboStatus.SelectedItem?.ToString()) || cboStatus.SelectedItem.ToString() != "В работе")
            {
                Log.Warning("Attempt to add parts to order with invalid status: {Status}",
                    cboStatus.SelectedItem?.ToString() ?? "null");
                ShowNotification("Комплектующие можно добавлять только для заказов в статусе 'В работе'.", "Предупреждение");
                return;
            }

            string partName = cboParts.SelectedItem.ToString();
            int quantity = (int)nudPartQuantity.Value;

            Log.Debug("Adding part: {PartName}, Model: {Model}, Quantity: {Quantity}",
                partName, partModel, quantity);

            var newPart = new Part
            {
                Name = partName,
                Model = partModel,
                Quantity = quantity
            };

            var existingPart = _selectedParts.FirstOrDefault(p => p.Name == partName && p.Model == partModel);
            if (existingPart != null)
            {
                existingPart.Quantity += quantity;
                Log.Debug("Updated existing part quantity to {NewQuantity}", existingPart.Quantity);
            }
            else
            {
                _selectedParts.Add(newPart);
                Log.Debug("Added new part to order");
            }

            dgvParts.DataSource = null;
            dgvParts.DataSource = _selectedParts.ToList();
            Log.Information("Parts list updated. Total parts: {Count}", _selectedParts.Count);

            txtPartModel.Clear();
            cboParts.SelectedIndex = -1;
            nudPartQuantity.Value = 1;
        }

        private async void BtnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                Log.Warning("Order update attempted without selection");
                ShowNotification("Пожалуйста, выберите заказ.", "Предупреждение");
                return;
            }
            if (cboStatus.SelectedIndex == -1)
            {
                Log.Warning("Order update attempted without status selection");
                ShowNotification("Пожалуйста, выберите статус.", "Предупреждение");
                return;
            }

            try
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                Log.Debug("Updating order ID: {OrderId}", selectedOrder.OrderId);

                var orderRequest = new OrderRequest
                {
                    OrderId = selectedOrder.OrderId,
                    CustomerName = selectedOrder.CustomerName,
                    PhoneNumber = selectedOrder.PhoneNumber,
                    DeviceType = selectedOrder.DeviceType,
                    DeviceModel = selectedOrder.DeviceModel,
                    RepairType = selectedOrder.RepairType,
                    Description = txtDescription.Text,
                    Status = cboStatus.SelectedItem.ToString(),
                    OrderDate = DateTime.ParseExact(selectedOrder.OrderDate, DateFormat, CultureInfo.InvariantCulture).ToString("dd-MM-yyyy"),
                    ResponsibleMaster = _authenticatedMaster.FullName,
                    Price = selectedOrder.Price
                };

                orderRequest.Parts.AddRange(_selectedParts);

                await _ordersClient.UpdateOrderAsync(orderRequest);
                Log.Information("Order updated successfully");
                ShowNotification("Заказ успешно обновлён.", "Успех");

                ClearInputFields();
                LoadOrders();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to update order");
                ShowNotification("Ошибка при обновлении заказа: " + ex.Message, "Ошибка");
            }
        }
        private async void BtnOrderToWarehouse_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                var request = new OrderRequest
                {
                    OrderId = selectedOrder.OrderId,
                    WarehouseRequestStatus = "Заявка отправлена"
                };

                await _ordersClient.UpdateWarehouseRequestStatusAsync(request);
                ShowNotification("Заявка на склад отправлена", "Успех");
                LoadOrders();
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.InvalidArgument)
            {
                ShowNotification(ex.Status.Detail, "Ошибка");
            }
            catch (Exception ex)
            {
                ShowNotification($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private async void BtnUpdateWarehouseStatus_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                var request = new OrderRequest { OrderId = selectedOrder.OrderId };

                var response = await _ordersClient.ProcessWarehouseRequestAsync(request);
                ShowNotification("Комплектующие выданы со склада", "Успех");
                LoadOrders();
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.FailedPrecondition)
            {
                ShowNotification("Сначала отправьте заявку на склад", "Ошибка");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.ResourceExhausted)
            {
                ShowNotification(ex.Status.Detail, "Не хватает деталей");
            }
            catch (Exception ex)
            {
                ShowNotification($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private async Task LoadParts(string orderId)
        {
            Log.Debug("Loading parts for order ID: {OrderId}", orderId);
            try
            {
                _selectedParts.Clear();
                var orderRequest = new OrderRequest { OrderId = orderId };
                var partsResponse = await _ordersClient.GetOrderPartsAsync(orderRequest);
                _selectedParts = partsResponse.Parts.ToList();

                dgvParts.DataSource = _selectedParts;
                dgvParts.Columns["Price"].Visible = false;
                dgvParts.Columns["Name"].HeaderText = "Название";
                dgvParts.Columns["Model"].HeaderText = "Модель";
                dgvParts.Columns["Quantity"].HeaderText = "Количество";

                Log.Debug("Loaded {Count} parts for order", _selectedParts.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load parts for order");
                ShowNotification("Ошибка при загрузке комплектующих.", "Ошибка");
            }
        }

        private async void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedOrder = dgvOrders.Rows[e.RowIndex].DataBoundItem as dynamic;
                if (selectedOrder != null)
                {
                    txtDescription.Text = selectedOrder.Description;
                    cboStatus.SelectedItem = selectedOrder.Status;
                    await LoadParts(selectedOrder.OrderId);
                }
            }
        }


        private void RemoveRart_Click(object sender, EventArgs e)
        {
            Log.Debug("Attempting to remove part from order");

            if (dgvParts.SelectedRows.Count == 0)
            {
                Log.Warning("No part selected for removal");
                ShowNotification("Пожалуйста, выберите комплектующее для удаления.", "Предупреждение");
                return;
            }

            var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
            if (selectedOrder != null && selectedOrder.WarehouseRequestStatus == "Заявка отправлена")
            {
                Log.Warning("Attempt to remove parts after warehouse request was sent");
                ShowNotification("Невозможно удалить комплектующие, так как заявка на склад уже отправлена.", "Предупреждение");
                return;
            }

            var selectedPart = dgvParts.SelectedRows[0].DataBoundItem as Part;
            if (selectedPart != null)
            {
                Log.Information("Removing part: {PartName} (Model: {Model}, Qty: {Quantity})",
                    selectedPart.Name, selectedPart.Model, selectedPart.Quantity);
                _selectedParts.Remove(selectedPart);
                dgvParts.DataSource = null;
                dgvParts.DataSource = _selectedParts.ToList();
                Log.Debug("Part removed successfully. Remaining parts: {Count}", _selectedParts.Count);
            }
        }


        private void dgvContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem selectedItem = e.ClickedItem as ToolStripMenuItem;

            if (selectedItem != null)
            {
                selectedItem.Checked = !selectedItem.Checked;

                if (selectedItem.Checked)
                {
                    flagEndOrders = true;
                    LoadOrders();
                }
                else
                {
                    flagEndOrders = false;
                    LoadOrders();
                }
            }
        }
        private bool keyHandled = false;
        private void MasterForm_KeyUp(object sender, KeyEventArgs e)
        {
            keyHandled = false;
        }

        private void MasterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyHandled) return;

            if (e.KeyCode == Keys.Escape)
            {
                Log.Debug("Escape key pressed - clearing selection and inputs");
                ClearInputFields();
                dgvOrders.ClearSelection();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                Log.Debug("F5 key pressed - refreshing orders");
                keyHandled = true;
                LoadOrders();
                e.Handled = true;
            }
        }

        public void SubscribeToQueue()
        {
            Log.Information("Subscribing to RabbitMQ queue");
            var factory = new ConnectionFactory()
            {
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST"),
                Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? "5672"),
                UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME"),
                Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD"),
                VirtualHost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST"),
                AutomaticRecoveryEnabled = true,
            };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.QueueDeclare(
                    queue: "orders_queue",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                _channel.BasicQos(prefetchSize: 0, prefetchCount: 15, global: false);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var order = JsonConvert.DeserializeObject<OrderRequest>(message);
                        Log.Debug("Received order from queue: {OrderId}", order.OrderId);

                        _pendingOrders[order.OrderId] = (order, ea.DeliveryTag);

                        this.Invoke((MethodInvoker)delegate
                        {
                            switch (_authenticatedMaster.Specialization)
                            {
                                case "Ремонт ПК":
                                    if (order.DeviceType.Equals("ПК") && !order.RepairType.Equals("Обслуживание")) _queueOrders.Add(order);
                                    break;
                                case "Ремонт телефонов":
                                    if ((order.DeviceType.Equals("Смартфон") || order.DeviceType.Equals("Планшет")) && !order.RepairType.Equals("Обслуживание")) _queueOrders.Add(order);
                                    break;
                                case "Ремонт ноутбуков":
                                    if (order.DeviceType.Equals("Ноутбук") && !order.RepairType.Equals("Обслуживание")) _queueOrders.Add(order);
                                    break;
                                case "Мастер по обслуживанию":
                                    if (order.DeviceType.Equals("Периферия") || order.RepairType.Equals("Обслуживание")) _queueOrders.Add(order);
                                    break;
                                case "Старший мастер":
                                    _queueOrders.Add(order);
                                    break;
                            }
                            UpdateQueueGridView();
                        });
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Error processing queued order");
                        _channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: true);
                    }
                };

                _channel.BasicConsume(
                    queue: "orders_queue",
                    autoAck: false,
                    consumer: consumer);

                Log.Information("Successfully subscribed to queue");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to subscribe to queue");
                _channel?.Close();
                _connection?.Close();
            }
        }
        private void UpdateQueueGridView()
        {
            dgvQueue.DataSource = null;

            dgvQueue.DataSource = _queueOrders;

            dgvQueue.Columns["OrderId"].HeaderText = "ID Заказа";
            dgvQueue.Columns["CustomerName"].HeaderText = "Имя клиента";
            dgvQueue.Columns["PhoneNumber"].HeaderText = "Телефон";
            dgvQueue.Columns["DeviceType"].HeaderText = "Тип устройства";
            dgvQueue.Columns["DeviceModel"].HeaderText = "Модель устройства";
            dgvQueue.Columns["RepairType"].HeaderText = "Тип ремонта";
            dgvQueue.Columns["Description"].HeaderText = "Описание";
            dgvQueue.Columns["Status"].HeaderText = "Статус";
            dgvQueue.Columns["OrderDate"].HeaderText = "Дата заказа";
            dgvQueue.Columns["Price"].HeaderText = "Цена";
            
            dgvQueue.Columns["OrderId"].Visible = false;
            dgvQueue.Columns["ResponsibleMaster"].Visible = false;
            dgvQueue.Columns["WarehouseRequestStatus"].Visible = false;
            dgvQueue.Columns["Price"].Visible = false;
        }

        private async void buttonAcceptOrder_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                Log.Warning("Order acceptance attempted without selection");
                ShowNotification("Пожалуйста, выберите заказ из очереди.", "Предупреждение");
                return;
            }

            var selectedOrder = dgvQueue.SelectedRows[0].DataBoundItem as OrderRequest;
            if (selectedOrder == null || !_pendingOrders.TryGetValue(selectedOrder.OrderId, out var pendingOrder))
            {
                Log.Warning("Order not found in pending orders");
                ShowNotification("Не удалось найти выбранный заказ.", "Ошибка");
                return;
            }

            try
            {
                Log.Debug("Accepting order ID: {OrderId}", selectedOrder.OrderId);

                // Обновляем только нужные поля, но оставляем остальные данные
                selectedOrder.ResponsibleMaster = _authenticatedMaster.FullName;
                selectedOrder.Status = "В работе";

                // Передаём ВЕСЬ объект selectedOrder, а не новый пустой OrderRequest
                await _ordersClient.UpdateOrderAsync(selectedOrder);

                _channel.BasicAck(pendingOrder.deliveryTag, multiple: false);
                _pendingOrders.Remove(selectedOrder.OrderId);
                _queueOrders.Remove(selectedOrder);

                UpdateQueueGridView();
                LoadOrders();
                Log.Information("Order accepted successfully");
                ShowNotification("Заказ успешно принят.", "Успех");
                tabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to accept order");
                ShowNotification($"Ошибка при принятии заказа: {ex.Message}", "Ошибка");
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            Log.Debug("Tab changed to index: {TabIndex}", tabControl1.SelectedIndex);

            if (tabControl1.SelectedIndex == 0)
            {
                Log.Information("Switched to Orders tab");
                DisconnectFromQueue();
                dgvQueue.Rows.Clear();
                LoadOrders();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Log.Information("Switched to Queue tab");
                if (_connection == null || !_connection.IsOpen)
                {
                    Log.Debug("Establishing new queue connection");
                    SubscribeToQueue();
                }
            }
        }
        private void DisconnectFromQueue()
        {
            if (_channel != null && _channel.IsOpen)
            {
                Log.Information("Disconnecting from RabbitMQ queue");
                _channel.Close();
                _connection.Close();
                _channel = null;
                _connection = null;
                Log.Debug("Queue connection closed successfully");
            }
            else
            {
                Log.Debug("No active queue connection to disconnect");
            }
        }
    }
}

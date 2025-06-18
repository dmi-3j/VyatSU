using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Net.Client;
using DotNetEnv;
using System.IO;
using Grpc.Core;
using System.Collections.Generic;
using Serilog;


namespace OrderClient
{
    public partial class OrderForm : Form
    {
        private OrdersService.OrdersServiceClient _ordersClient;
        private bool flagEndOrders = false;
        private bool flagDeliveredOrders = false;
        private const string DateFormat = "dd.MM.yyyy";

        public OrderForm() : this(null)
        {
        }

        public OrderForm(OrdersService.OrdersServiceClient ordersClient)
        {
            InitializeComponent();

            if (ordersClient != null)
            {
                _ordersClient = ordersClient; 
            }
            else
            {
                InitializeGrpcClient(); 
            }

            LoadOrders();
            InitComboBoxes();
            this.KeyUp += OrderForm_KeyUp;
            this.KeyDown += OrderForm_KeyDown;
            this.KeyPreview = true;
            dgvOrders.ContextMenuStrip = dgvContextMenu;
            this.Load += async (s, e) => await LoadOrders();

        }

        private void InitializeGrpcClient()
        {
            try
            {
                var address = Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS");
                var channel = GrpcChannel.ForAddress(address);
                _ordersClient = new OrdersService.OrdersServiceClient(channel);
                Log.Information("gRPC client initialized for {Address}", address);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Failed to initialize gRPC client");
                ShowNotification("Ошибка подключения к серверу", "Ошибка");
                throw;
            }
        }

        private void InitSearchControls()
        {
            btnSearch = new Button { Text = "Поиск", Width = 100 };
            btnSearch.Click += btnSearch_Click;
        }

        public async Task LoadOrders(string searchQuery = "")
        {
            ClearInputFields();
            bool isSuccess = false;
            Log.Debug("Loading orders. Filter: {Filter}, Search: {Search}",
                   flagEndOrders ? "Ready" : flagDeliveredOrders ? "Delivered" : "All",
                   searchQuery);

            while (!isSuccess)
            {
                try
                {
                    var request = new GetOrdersRequest
                    {
                        StatusFilter = flagEndOrders ? "Готов к выдаче" :
                                       flagDeliveredOrders ? "Выдан" : " ",
                        SearchQuery = searchQuery
                    };

                    var ordersResponse = await _ordersClient.GetOrdersAsync(request);

                    var orders = ordersResponse.Orders
                        .Where(order => string.IsNullOrEmpty(searchQuery) ||
                            order.CustomerName.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            order.PhoneNumber.Contains(searchQuery))
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
                            order.OrderDate,
                            order.ResponsibleMaster,
                            order.Price,
                            Parts = string.Join(", ", order.Parts.Select(p => $"{p.Name} (x{p.Quantity})")),
                        }).ToList();

                    Log.Information("Loaded {Count} orders", orders.Count);
                    dgvOrders.DataSource = orders;
                    SetColumnHeaders();
                    isSuccess = true;
                    dgvOrders.ClearSelection();
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
                {
                    Log.Error(ex, "gRPC service unavailable");
                    ShowNotification("Сервер недоступен. Попытка переподключения...", "Ошибка");
                    await Task.Delay(5000);
                    await LoadOrders(searchQuery); 
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Failed to load orders");
                    ShowNotification($"Ошибка загрузки: {ex.Message}", "Ошибка");
                    break;
                }
            }
        }

        private void SetColumnHeaders()
        {
            var headers = new[]{"Имя клиента", "Телефон", "Тип устройства", "Модель устройства",
        "Тип ремонта", "Описание", "Статус", "Дата заказа", "Мастер", "Цена"};
            for (int i = 0; i < headers.Length; i++)
                dgvOrders.Columns[i + 1].HeaderText = headers[i];

            dgvOrders.Columns["OrderId"].Visible = false;
            dgvOrders.Columns["Parts"].Visible = false;
            if (dgvOrders.Columns.Contains("OrderDate"))
            {
                dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
        }

        private void InitComboBoxes()
        {
            deviceTypeCmb.Items.AddRange(new[] { "Смартфон", "Ноутбук", "Планшет", "ПК", "Периферия", "Комплектующие" });
            typeRepairCmb.Items.AddRange(new[] { "Установка ПО", "Замена комплектующих", "Компонентный ремонт", "Обслуживание" });
            dgvOrders.ContextMenuStrip = dgvContextMenu;
            dgvOrders.CellMouseClick += dgvOrders_CellMouseClick;
            this.KeyPreview = true;
            this.KeyUp += OrderForm_KeyUp;
            this.KeyDown += OrderForm_KeyDown;
        }

        private void ClearInputFields()
        {
            txtCustomerName.Clear();
            txtDescription.Clear();
            deviceTypeCmb.SelectedItem = null;
            txtDeviceModel.Clear();
            typeRepairCmb.SelectedItem = null;
            txtPhoneNumber.Clear();
            txtPrice.Clear();
        }

        private void ShowNotification(string message, string type)
        {
            notifyIcon1.BalloonTipText = message;
            if (type.Equals("Ошибка"))
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            }
            else if (type.Equals("Успех"))
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            }
            else if (type.Equals("Предупреждение"))
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
            }
                notifyIcon1.ShowBalloonTip(3000);
            Log.Debug("$Notification shown: - {Message}", message);
        }

        public async Task btnCreateOrder_Click(object sender, EventArgs e)
        {
            Log.Debug("Starting order creation");

            if (string.IsNullOrEmpty(txtCustomerName.Text) ||
                string.IsNullOrEmpty(txtDescription.Text) ||
                string.IsNullOrEmpty(txtDeviceModel.Text) ||
                typeRepairCmb.SelectedItem == null ||
                string.IsNullOrEmpty(txtPhoneNumber.Text) ||
                deviceTypeCmb.SelectedItem == null ||
                string.IsNullOrEmpty(txtPrice.Text))
            {
                Log.Warning("Order creation validation failed - missing required fields");
                ShowNotification("Пожалуйста, заполните все поля.", "Предупреждение");
                return;
            }

            double price;
            if (!double.TryParse(txtPrice.Text.Trim(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out price))
            {
                ShowNotification("Пожалуйста, введите корректную цену.", "Предупреждение");
                return;
            }

            try
            {
                var orderRequest = new OrderRequest
                {
                    CustomerName = txtCustomerName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    DeviceType = deviceTypeCmb.SelectedItem.ToString(),
                    DeviceModel = txtDeviceModel.Text,
                    RepairType = typeRepairCmb.SelectedItem.ToString(),
                    Description = txtDescription.Text,
                    OrderDate = DateTime.Now.ToString("dd-MM-yyyy"),
                    ResponsibleMaster = "",
                    Price = price
                };

                await _ordersClient.CreateOrderAsync(orderRequest);
                Log.Information("Order created for  {CustomerName}, {DeviceModel}",
                            orderRequest.CustomerName, orderRequest.DeviceModel);
                ShowNotification("Заказ успешно создан.", "Успех");
                ClearInputFields();
                LoadOrders();
            }
            catch (RpcException ex)
            {
                Log.Error(ex, "gRPC error. Status: {Status}", ex.Status);
                Log.Error(ex, "gRPC communication failure while creating order. " +
                    $"Status: {ex.Status.StatusCode}, " +
                    $"Detail: {ex.Status.Detail}. ");
                Log.Error(
                    "Order data that failed: {@OrderRequest}", new
                    {
                        CustomerName = txtCustomerName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        DeviceType = deviceTypeCmb.SelectedItem?.ToString(),
                        DeviceModel = txtDeviceModel.Text,
                        RepairType = typeRepairCmb.SelectedItem?.ToString(),
                        Description = txtDescription.Text,
                        Price = price
                    });
                ShowNotification($"Ошибка при создании заказа: {ex.Status.Detail}", "Ошибка");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Order creation failed");
                Log.Error(ex, "Unexpected error during order creation. " +
                    "Failed order data: {@OrderRequest}", new
                    {
                        CustomerName = txtCustomerName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        DeviceType = deviceTypeCmb.SelectedItem?.ToString(),
                        DeviceModel = txtDeviceModel.Text,
                        RepairType = typeRepairCmb.SelectedItem?.ToString(),
                        Description = txtDescription.Text,
                        Price = price
                    });
                ShowNotification($"Неизвестная ошибка: {ex.Message}", "Ошибка");
            }
        }
        private List<Part> _selectedParts = new List<Part>();
        private async void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                Log.Warning("Update order attempted without selection");
                ShowNotification("Пожалуйста, выберите заказ для обновления.", "Предупреждение");
                return;
            }

            try
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedOrder == null)
                {
                    Log.Error("Selected order data is null");
                    MessageBox.Show("Не удалось получить данные выбранного заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double price;
                Log.Debug("Starting update for order ID: {OrderId}", selectedOrder.OrderId);
                if (!double.TryParse(txtPrice.Text, out price))
                {
                    Log.Warning("Invalid price format entered: {PriceText}", txtPrice.Text);
                    ShowNotification("Пожалуйста, введите корректную цену.", "Предупреждение");
                    return;
                }

                var orderRequest = new OrderRequest
                {
                    OrderId = selectedOrder.OrderId,
                    CustomerName = txtCustomerName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    DeviceType = deviceTypeCmb.SelectedItem.ToString(),
                    DeviceModel = txtDeviceModel.Text,
                    RepairType = typeRepairCmb.SelectedItem.ToString(),
                    Description = txtDescription.Text,
                    Status = selectedOrder.Status,
                    OrderDate = selectedOrder.OrderDate,
                    ResponsibleMaster = selectedOrder.ResponsibleMaster,
                    Price = price
                };

                orderRequest.Parts.AddRange(_selectedParts);
                Log.Information("Updating order with {PartCount} parts", _selectedParts.Count);
                var updatedOrder = await _ordersClient.UpdateOrderAsync(orderRequest);
                Log.Information("Order {OrderId} successfully updated", selectedOrder.OrderId);
                ShowNotification("Заказ успешно обновлен.", "Успех");
                this.Invoke((MethodInvoker)delegate {
                    LoadOrders();
                });
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                Log.Error(ex, "Order not found on server. Attempted update data: {@OrderData}", new
                {
                    OrderId = (dgvOrders.SelectedRows[0].DataBoundItem as dynamic)?.OrderId,
                    CustomerName = txtCustomerName.Text,
                    DeviceModel = txtDeviceModel.Text
                });
                ShowNotification("Order not found on server", "Error");
            }
            catch (RpcException ex)
            {
                Log.Error(ex, "gRPC communication error updating order. Status: {StatusCode}. Full order data: {@OrderData}",
                    ex.StatusCode, new
                    {
                        OrderId = (dgvOrders.SelectedRows[0].DataBoundItem as dynamic)?.OrderId,
                        CustomerName = txtCustomerName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        DeviceType = deviceTypeCmb.SelectedItem?.ToString(),
                        DeviceModel = txtDeviceModel.Text,
                        RepairType = typeRepairCmb.SelectedItem?.ToString(),
                        Price = txtPrice.Text,
                        PartCount = _selectedParts.Count
                    });
                ShowNotification($"Update failed: {ex.Status.Detail}", "Error");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error updating order. Context: {@Context}", new
                {
                    SelectedOrderId = (dgvOrders.SelectedRows[0].DataBoundItem as dynamic)?.OrderId,
                    Environment.UserName,
                    Timestamp = DateTime.UtcNow
                });
                ShowNotification($"Update failed: {ex.Message}", "Error");
            }
        }


        private async void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                Log.Warning("Delete operation attempted without order selection");
                ShowNotification("Пожалуйста, выберите заказ для удаления.", "Предупреждение");
                return;
            }

            try
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedOrder == null)
                {
                    Log.Error("Failed to get selected order data");
                    ShowNotification("Не удалось получить данные выбранного заказа.", "Ошибка");
                    return;
                }
                Log.Information("Attempting to delete order ID: {OrderId}", selectedOrder.OrderId);
                var orderRequest = new OrderRequest
                {
                    OrderId = selectedOrder.OrderId
                };

                await _ordersClient.DeleteOrderAsync(orderRequest);
                Log.Information("Order {OrderId} successfully deleted", selectedOrder.OrderId);
                LoadOrders();

                var orders = dgvOrders.DataSource as System.Collections.Generic.List<dynamic>;
                if (orders != null)
                {
                    int index = 1;
                    foreach (var order in orders)
                    {
                        order.OrderId = index.ToString();
                        index++;
                    }
                }

                dgvOrders.DataSource = null;
                dgvOrders.DataSource = orders;
                ShowNotification("Заказ успешно удален.", "Успех");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                var orderId = (dgvOrders.SelectedRows[0].DataBoundItem as dynamic)?.OrderId;
                Log.Error(ex, "Order not found on server. Order ID: {OrderId}", orderId);
                ShowNotification($"Order not found on server (ID: {orderId})", "Error");
            }
            catch (RpcException ex)
            {
                var orderId = (dgvOrders.SelectedRows[0].DataBoundItem as dynamic)?.OrderId;
                Log.Error(ex, "gRPC error deleting order. Status: {StatusCode}, Order ID: {OrderId}",
                    ex.StatusCode, orderId);
                ShowNotification($"Communication error (Order ID: {orderId}): {ex.Status.Detail}", "Error");
            }
            catch (Exception ex)
            {
                var orderId = (dgvOrders.SelectedRows[0].DataBoundItem as dynamic)?.OrderId;
                Log.Error(ex, "Unexpected error during deletion of order {OrderId}", orderId);
                ShowNotification($"Internal error (Order ID: {orderId}): {ex.Message}", "Error");
            }
        }

        private void dgvOrders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0 && dgvOrders.SelectedRows[0].Index >= 0)
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                
                if (selectedOrder != null)
                {
                   
                    txtCustomerName.Text = selectedOrder.CustomerName;
                    txtDescription.Text = selectedOrder.Description;
                    deviceTypeCmb.SelectedItem = selectedOrder.DeviceType;
                    txtDeviceModel.Text = selectedOrder.DeviceModel;
                    typeRepairCmb.SelectedItem = selectedOrder.RepairType;
                    txtPhoneNumber.Text = selectedOrder.PhoneNumber;
                    txtPrice.Text = selectedOrder.Price.ToString();
                }
            }
        }

        private void dgvContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem selectedItem = e.ClickedItem as ToolStripMenuItem;

            if (selectedItem != null)
            {
                if (selectedItem.Checked)
                {
                    selectedItem.Checked = false;
                    flagEndOrders = false;
                    flagDeliveredOrders = false;
                }
                else
                {
                    foreach (ToolStripMenuItem item in dgvContextMenu.Items)
                    {
                        item.Checked = false;
                    }

                    selectedItem.Checked = true;

                    if (selectedItem.Text == "Готовые к выдаче")
                    {
                        flagEndOrders = true;
                        flagDeliveredOrders = false;
                    }
                    else if (selectedItem.Text == "Выданные заказы")
                    {
                        flagEndOrders = false;
                        flagDeliveredOrders = true;
                    }
                }

                LoadOrders();
            }
        }
        private bool keyHandled = false;
        private void OrderForm_KeyUp(object sender, KeyEventArgs e)
        {
            keyHandled = false;
        }

        private void OrderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyHandled) return;

            if (e.KeyCode == Keys.Escape)
            {
                txtSearch.Clear();
                LoadOrders();

                dgvOrders.ClearSelection();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                keyHandled = true;
                LoadOrders();
                e.Handled = true;
            }
        }


        private async void btnMarkAsDelivered_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                Log.Warning("Attempt to mark order as delivered without selection");
                ShowNotification("Пожалуйста, выберите заказ для выдачи.", "Предупреждение");
                return;
            }

            try
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedOrder == null)
                {
                    Log.Error("Failed to get selected order data");
                    ShowNotification("Не удалось получить данные выбранного заказа.", "Ошибка");
                    return;
                }
                Log.Information("Starting to mark order {OrderId} as delivered", selectedOrder.OrderId);
                var orderRequest = new OrderRequest
                {
                    OrderId = selectedOrder.OrderId
                };
                Log.Debug("Sending mark as delivered request for order {OrderId}", selectedOrder.OrderId);
                await _ordersClient.MarkOrderAsDeliveredAsync(orderRequest);
                Log.Information("Successfully marked order {OrderId} as delivered", selectedOrder.OrderId);
                ShowNotification("Заказ успешно выдан.", "Успех");
           
                Log.Debug("Reloading orders list after marking as delivered");
                LoadOrders();
            }
            catch (RpcException ex)
            {
                Log.Error(ex, "gRPC error while marking order as delivered. Status: {StatusCode}, Detail: {Detail}",
                    ex.StatusCode, ex.Status.Detail);
                ShowNotification("Ошибка при выдаче заказа.", "Ошибка");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error while marking order as delivered");
                ShowNotification("Ошибка при выдаче заказа.", "Ошибка");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            LoadOrders(searchQuery);
        }
    }
}
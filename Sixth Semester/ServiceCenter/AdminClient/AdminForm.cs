using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using Grpc.Net.Client;
using Serilog;
using ServiceCenter;


namespace AdminClient
{
    public partial class AdminForm : Form
    {
        private OrdersService.OrdersServiceClient _ordersClient;
        private MastersService.MastersServiceClient _mastersClient;
        private bool flagEndOrders = false;
        private bool flagDeliveredOrders = false;
        private bool keyHandled = false;
        private List<Part> _selectedParts = new List<Part>();

        public AdminForm()
        {
            InitializeComponent();
            Log.Information("Initializing AdminForm");

            InitializeGrpcClient();
            LoadOrders();
            LoadMasters();
            InitComboBoxes();

            this.KeyUp += AdminForm_KeyUp;
            this.KeyDown += AdminForm_KeyDown;
            this.KeyPreview = true;
            dgvOrders.ContextMenuStrip = dgvContextMenu;
            dgvOrders.CellMouseClick += dgvOrders_CellMouseClick;
            dgvMasters.SelectionChanged += dgvMasters_SelectionChanged;

            Log.Debug("AdminForm initialization completed");
        }

        private void InitializeGrpcClient()
        {
            try
            {
                var channel = GrpcChannel.ForAddress(Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS"));
                _ordersClient = new OrdersService.OrdersServiceClient(channel);
                _mastersClient = new MastersService.MastersServiceClient(channel);
                txtContactInfo.Mask = "+7 (000) 000-00-00";
                Log.Information("gRPC clients initialized successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to initialize gRPC clients");
                //throw;
            }
        }
        private void ShowNotification(string message, string type)
        {
            Log.Debug("Showing notification. Type: {NotificationType}, Message: {Message}", type, message);
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
        }

        private async Task LoadMasters()
        {
            Log.Debug("Loading masters list");
            ClearInputFieldsMaster();

            try
            {
                var response = await _mastersClient.GetMastersAsync(new GetMastersRequest());
                dgvMasters.DataSource = response.Masters;
                SetColumnHeadersForMasters();
                dgvMasters.ClearSelection();
                Log.Information("Successfully loaded {MasterCount} masters", response.Masters.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load masters");
                ShowNotification($"Ошибка при загрузке мастеров: {ex.Message}", "Ошибка");
            }
        }


        private void InitSearchControls()
        {
            btnSearch = new Button { Text = "Поиск", Width = 100 };
            btnSearch.Click += btnSearch_Click;
        }

        private async void LoadOrders(string searchQuery = "")
        {
            Log.Debug("Loading orders. Filter: {StatusFilter}, Search: {SearchQuery}",
                flagEndOrders ? "Ready" : flagDeliveredOrders ? "Delivered" : "All",
                searchQuery);

            ClearInputFields();
            bool isSuccess = false;

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
                            Parts = string.Join(", ", order.Parts.Select(p => $"{p.Name} (x{p.Quantity})"))
                        })
                        .ToList();

                    dgvOrders.DataSource = orders;
                    dgvOrders.Columns["OrderId"].Visible = false;
                    SetColumnHeaders();
                    isSuccess = true;
                    dgvOrders.ClearSelection();
                    Log.Information("Successfully loaded {OrderCount} orders", orders.Count);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Failed to load orders. Retrying in 5 seconds...");
                    ShowNotification("Ошибка при загрузке заказов. Попытка переподключения через 5 секунд...", "Ошибка");
                    await Task.Delay(5000);
                }
            }
        }

        private void SetColumnHeaders()
        {
            var headers = new[]{"Имя клиента", "Телефон", "Тип устройства", "Модель устройства",
                "Тип ремонта", "Описание", "Статус","Дата заказа", "Мастер", "Комплектующие"};
            for (int i = 0; i < headers.Length; i++)
                dgvOrders.Columns[i + 1].HeaderText = headers[i];
            dgvOrders.Columns["OrderId"].Visible = false;
            if (dgvOrders.Columns.Contains("OrderDate"))
            {
                dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
        }

        private void ClearInputFields()
        {
            txtCustomerName.Clear();
            txtDescription.Clear();
            deviceTypeCmb.SelectedItem = null;
            txtDeviceModel.Clear();
            typeRepairCmb.SelectedItem = null;
            txtPhoneNumber.Clear();
            cboStatus.SelectedIndex = -1;
            cboParts.SelectedIndex = -1;
            nudPartQuantity.Value = 1;
            _selectedParts.Clear();
            dgvParts.DataSource = null;
        }

        private void InitComboBoxes()
        {
            deviceTypeCmb.Items.AddRange(new[] { "Смартфон", "Ноутбук", "Планшет", "ПК", "Периферия" });
            typeRepairCmb.Items.AddRange(new[] { "Установка ПО", "Замена комплектующих", "Компонентный ремонт", "Обслуживание" });
            cboStatus.Items.AddRange(new[] {"В работе", "Готов к выдаче", "Выдан", "Отменён" });
            cboParts.Items.AddRange(new[] { "Дисплей", "Аккумулятор", "Клавиатура", "Материнская плата" });
            cmbSpecialization.Items.AddRange(new[] { "Ремонт ПК", "Ремонт телефонов", "Ремонт ноутбуков", "Мастер по обслуживанию", "Старший мастер" });
            dgvOrders.ContextMenuStrip = dgvContextMenu;
            dgvOrders.CellMouseClick += dgvOrders_CellMouseClick;
            this.KeyPreview = true;
            this.KeyUp += AdminForm_KeyUp;
            this.KeyDown += AdminForm_KeyDown;
        }
        private async void btnCreateOrder_Click(object sender, EventArgs e) => await CreateOrder();
        private async void btnUpdateOrder_Click(object sender, EventArgs e) => await UpdateOrder();
        private async void btnDeleteOrder_Click(object sender, EventArgs e) => await DeleteOrder();
        private void BtnAddPart_Click(object sender, EventArgs e) => AddPart();
        private void RemoveRart_Click(object sender, EventArgs e) => RemovePart();


        private async Task CreateOrder()
        {
            Log.Debug("Starting order creation");

            if (string.IsNullOrEmpty(txtCustomerName.Text) ||
                string.IsNullOrEmpty(txtDescription.Text) ||
                string.IsNullOrEmpty(txtDeviceModel.Text) ||
                typeRepairCmb.SelectedItem == null ||
                string.IsNullOrEmpty(txtPhoneNumber.Text) ||
                deviceTypeCmb.SelectedItem == null)
            {
                Log.Warning("Order creation validation failed - missing required fields");
                ShowNotification("Пожалуйста, заполните все поля.", "Предупреждение");
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
                    ResponsibleMaster = ""
                };

                Log.Information("Creating new order for customer: {CustomerName}", orderRequest.CustomerName);
                await _ordersClient.CreateOrderAsync(orderRequest);

                Log.Information("Order created successfully");
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
                        
                    });
                ShowNotification($"Неизвестная ошибка: {ex.Message}", "Ошибка");
            }
        }
        


        private async Task UpdateOrder()
        {
            Log.Debug("Starting order update");

            if (dgvOrders.SelectedRows.Count == 0)
            {
                Log.Warning("No order selected for update");
                ShowNotification("Пожалуйста, выберите заказ для обновления.", "Предупрежение");
                return;
            }

            try
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedOrder == null)
                {
                    Log.Warning("Failed to get selected order data");
                    ShowNotification("Не удалось получить данные выбранного заказа.", "Ошибка");
                    return;
                }

                Log.Information("Updating order ID: {OrderId}", selectedOrder.OrderId);
                var orderRequest = new OrderRequest
                {
                    OrderId = selectedOrder.OrderId,
                    CustomerName = txtCustomerName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    DeviceType = deviceTypeCmb.SelectedItem.ToString(),
                    DeviceModel = txtDeviceModel.Text,
                    RepairType = typeRepairCmb.SelectedItem.ToString(),
                    Description = txtDescription.Text,
                    Status = cboStatus.SelectedItem?.ToString() ?? selectedOrder.Status,
                    OrderDate = selectedOrder.OrderDate,
                    ResponsibleMaster = selectedOrder.ResponsibleMaster,
                };

                orderRequest.Parts.AddRange(_selectedParts);

                await _ordersClient.UpdateOrderAsync(orderRequest);

                Log.Information("Order updated successfully");
                ShowNotification("Заказ успешно обновлен.", "Успех");
                LoadOrders();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to update order");
                ShowNotification("Ошибка при обновлении заказа.", "Ошибка");
            }
        }
        private async Task DeleteOrder()
        {
            Log.Debug("Starting order deletion");

            if (dgvOrders.SelectedRows.Count == 0)
            {
                Log.Warning("No order selected for deletion");
                ShowNotification("Пожалуйста, выберите заказ для удаления.", "Предупреждение");
                return;
            }

            try
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedOrder == null)
                {
                    Log.Warning("Failed to get selected order data");
                    ShowNotification("Не удалось получить данные выбранного заказа.", "Ошибка");
                    return;
                }

                Log.Information("Deleting order ID: {OrderId}", selectedOrder.OrderId);
                var orderRequest = new OrderRequest
                {
                    OrderId = selectedOrder.OrderId
                };

                await _ordersClient.DeleteOrderAsync(orderRequest);

                Log.Information("Order deleted successfully");
                ShowNotification("Заказ успешно удален.", "Успех");
                LoadOrders();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to delete order");
                ShowNotification("Ошибка при удалении заказа.", "Ошибка");
            }
        }
        private void AddPart()
        {
            if (cboParts.SelectedIndex == -1)
            {
                Log.Warning("No part selected for addition");
                ShowNotification("Выберите комплектующую.", "Предупреждение");
                return;
            }

            string partName = cboParts.SelectedItem.ToString();
            int quantity = (int)nudPartQuantity.Value;
            Log.Debug("Adding part: {PartName}, Quantity: {Quantity}", partName, quantity);

            var existingPart = _selectedParts.FirstOrDefault(p => p.Name == partName);
            if (existingPart != null)
            {
                existingPart.Quantity += quantity;
                Log.Debug("Updated existing part quantity. New quantity: {Quantity}", existingPart.Quantity);
            }
            else
            {
                _selectedParts.Add(new Part { Name = partName, Quantity = quantity });
                Log.Debug("Added new part");
            }

            dgvParts.DataSource = null;
            dgvParts.DataSource = _selectedParts.ToList();

            cboParts.SelectedIndex = -1;
            nudPartQuantity.Value = 1;
        }


        private void RemovePart()
        {
            if (dgvParts.SelectedRows.Count == 0)
            {
                Log.Warning("Part removal attempted without selection");
                ShowNotification("Пожалуйста, выберите комплектующее для удаления.", "Предупреждение");
                return;
            }

            var selectedPart = dgvParts.SelectedRows[0].DataBoundItem as Part;
            if (selectedPart != null)
            {
                Log.Debug("Removing part: {PartName}", selectedPart.Name);
                _selectedParts.Remove(selectedPart);
                dgvParts.DataSource = null;
                dgvParts.DataSource = _selectedParts.ToList();
            }
        }

        private async void dgvOrders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0 && dgvOrders.SelectedRows[0].Index >= 0)
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedOrder != null)
                {
                    Log.Debug("Order selected: {OrderId}", selectedOrder.OrderId);

                    txtCustomerName.Text = selectedOrder.CustomerName;
                    txtDescription.Text = selectedOrder.Description;
                    deviceTypeCmb.SelectedItem = selectedOrder.DeviceType;
                    txtDeviceModel.Text = selectedOrder.DeviceModel;
                    typeRepairCmb.SelectedItem = selectedOrder.RepairType;
                    txtPhoneNumber.Text = selectedOrder.PhoneNumber;
                    cboStatus.SelectedItem = selectedOrder.Status;

                    await LoadParts(selectedOrder.OrderId);
                }
            }
        }
        private bool _isLoadingParts = false;

        private async Task LoadParts(string orderId)
        {
            if (_isLoadingParts) return;
            _isLoadingParts = true;
            Log.Debug("Loading parts for order: {OrderId}", orderId);

            try
            {
                var orderRequest = new OrderRequest { OrderId = orderId };
                var partsResponse = await _ordersClient.GetOrderPartsAsync(orderRequest);
                _selectedParts = partsResponse.Parts.ToList();
                dgvParts.DataSource = _selectedParts;

                if (dgvParts.Columns.Count > 0)
                {
                    dgvParts.Columns["Price"].HeaderText = "Цена";
                    dgvParts.Columns["Name"].HeaderText = "Название";
                    dgvParts.Columns["Model"].HeaderText = "Модель";
                    dgvParts.Columns["Quantity"].HeaderText = "Количество";
                }

                Log.Debug("Loaded {Count} parts for order", _selectedParts.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load parts for order {OrderId}", orderId);
                ShowNotification("Ошибка при загрузке комплектующих", "Ошибка");
            }
            finally
            {
                _isLoadingParts = false;
            }
        }

        private void dgvContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectedItem = e.ClickedItem as ToolStripMenuItem;
            if (selectedItem == null) return;

            Log.Debug("Context menu item clicked: {ItemText}", selectedItem.Text);

            if (selectedItem.Checked)
            {
                selectedItem.Checked = false;
                flagEndOrders = false;
                flagDeliveredOrders = false;
                Log.Debug("Filter cleared");
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
                    Log.Debug("Filter set to 'Ready for pickup'");
                }
                else if (selectedItem.Text == "Выданные заказы")
                {
                    flagEndOrders = false;
                    flagDeliveredOrders = true;
                    Log.Debug("Filter set to 'Delivered'");
                }
            }

            LoadOrders();
        }

        private void AdminForm_KeyUp(object sender, KeyEventArgs e)
        {
            keyHandled = false;
        }

        private void AdminForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyHandled) return;

            if (e.KeyCode == Keys.Escape)
            {
                Log.Debug("Escape key pressed - clearing selection");
                txtSearch.Clear();
                LoadOrders();
                dgvOrders.ClearSelection();
                dgvMasters.ClearSelection();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                Log.Debug("F5 key pressed - refreshing data");
                keyHandled = true;
                LoadOrders();
                LoadMasters();
                e.Handled = true;
            }
        }
        private void ClearInputFieldsMaster()
        {
            Log.Debug("Clearing master input fields");
            txtFullName.Clear();
            cmbSpecialization.SelectedIndex = -1;
            dtpBirthDate.Value = DateTime.Now;
            txtContactInfo.Clear();
            txtLogin.Clear();
            txtPassword.Clear();
        }

        private void SetColumnHeadersForMasters()
        {
            var headers = new[] { "ФИО", "Специализация", "Дата рождения", "Номер телефона", "Логин" };

            for (int i = 0; i < headers.Length; i++)
            {
                dgvMasters.Columns[i + 1].HeaderText = headers[i];
            }

            dgvMasters.Columns["MasterId"].Visible = false;
            dgvMasters.Columns["Password"].Visible = false;
            Log.Debug("Configured master grid columns");
        }


        private void dgvMasters_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvMasters.SelectedRows.Count > 0 && dgvMasters.SelectedRows[0].Index >= 0)
            {
                var selectedMaster = dgvMasters.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedMaster != null)
                {
                    dgvMasters.Rows[e.RowIndex].Selected = true;
                    txtFullName.Text = selectedMaster.FullName;
                    cmbSpecialization.Text = selectedMaster.Specialization;
                    dtpBirthDate.Value = DateTime.Parse(selectedMaster.BirthDate);
                    txtContactInfo.Text = selectedMaster.ContactInfo;
                    txtLogin.Text = selectedMaster.Login;
                    txtPassword.Text = selectedMaster.Password;
                }
            }
        }


        private void dgvMasters_SelectionChanged(object sender, EventArgs e)
        {
            ClearInputFieldsMaster();

            if (dgvMasters.SelectedRows.Count > 0)
            {
                var selectedMaster = dgvMasters.SelectedRows[0].DataBoundItem as Master;
                if (selectedMaster != null)
                {
                    Log.Debug("Master selected: {MasterId}", selectedMaster.MasterId);
                    txtFullName.Text = selectedMaster.FullName;
                    cmbSpecialization.Text = selectedMaster.Specialization;
                    dtpBirthDate.Value = DateTime.Parse(selectedMaster.BirthDate);
                    txtContactInfo.Text = selectedMaster.ContactInfo;
                    txtLogin.Text = selectedMaster.Login;
                    txtPassword.Text = selectedMaster.Password;
                }
            }
        }

        private async void btnAddMaster_Click(object sender, EventArgs e)
        {
            Log.Information("Starting master creation");

            if (string.IsNullOrEmpty(txtFullName.Text) ||
                string.IsNullOrEmpty(cmbSpecialization.Text) ||
                string.IsNullOrEmpty(txtContactInfo.Text) ||
                string.IsNullOrEmpty(txtLogin.Text) ||
                string.IsNullOrEmpty(txtPassword.Text))
            {
                Log.Warning("Master creation validation failed - missing required fields");
                ShowNotification("Пожалуйста, заполните все поля.", "Предупреждение");
                return;
            }

            var master = new Master
            {
                MasterId = Guid.NewGuid().ToString(),
                FullName = txtFullName.Text,
                Specialization = cmbSpecialization.Text,
                BirthDate = dtpBirthDate.Value.ToString("dd-MM-yyyy"),
                ContactInfo = txtContactInfo.Text,
                Login = txtLogin.Text,
                Password = txtPassword.Text
            };

            try
            {
                Log.Debug("Creating new master: {Login}", master.Login);
                var response = await _mastersClient.CreateMasterAsync(new CreateMasterRequest { Master = master });

                if (response.Success)
                {
                    Log.Information("Master created successfully");
                    ShowNotification(response.Message, "Успех");
                    await LoadMasters();
                }
                else
                {
                    Log.Warning("Master creation failed: {Message}", response.Message);
                    ShowNotification(response.Message, "Предупреждение");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Master creation failed");
                ShowNotification($"Ошибка при добавлении мастера: {ex.Message}", "Ошибка");
            }
        }


        private async void btnUpdateMaster_Click(object sender, EventArgs e)
        {
            Log.Information("Starting master update");

            var selectedMaster = dgvMasters.SelectedRows[0].DataBoundItem as Master;
            if (selectedMaster == null)
            {
                Log.Warning("Master update attempted without selection");
                ShowNotification("Выберите мастера для обновления.", "Предупреждение");
                return;
            }

            if (string.IsNullOrEmpty(txtFullName.Text) ||
                string.IsNullOrEmpty(cmbSpecialization.Text) ||
                string.IsNullOrEmpty(txtContactInfo.Text) ||
                string.IsNullOrEmpty(txtLogin.Text) ||
                string.IsNullOrEmpty(txtPassword.Text))
            {
                Log.Warning("Master update validation failed - missing required fields");
                ShowNotification("Пожалуйста, заполните все поля.", "Предупреждение");
                return;
            }

            selectedMaster.FullName = txtFullName.Text;
            selectedMaster.Specialization = cmbSpecialization.Text;
            selectedMaster.BirthDate = dtpBirthDate.Value.ToString("dd-MM-yyyy");
            selectedMaster.ContactInfo = txtContactInfo.Text;
            selectedMaster.Login = txtLogin.Text;
            selectedMaster.Password = txtPassword.Text;

            try
            {
                Log.Debug("Updating master: {MasterId}", selectedMaster.MasterId);
                var response = await _mastersClient.UpdateMasterAsync(new UpdateMasterRequest { Master = selectedMaster });

                if (response.Success)
                {
                    Log.Information("Master updated successfully");
                    ShowNotification("Мастер успешно обновлен.", "Успех");
                    await LoadMasters();
                }
                else
                {
                    Log.Warning("Master update failed: {Message}", response.Message);
                    ShowNotification(response.Message, "Предупреждение");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Master update failed");
                ShowNotification($"Ошибка при обновлении мастера: {ex.Message}", "Ошибка");
            }
        }

        private async void btnDeleteMaster_Click(object sender, EventArgs e)
        {
            Log.Information("Starting master deletion");

            var selectedMaster = dgvMasters.SelectedRows[0].DataBoundItem as Master;
            if (selectedMaster == null)
            {
                Log.Warning("Master deletion attempted without selection");
                ShowNotification("Выберите мастера для удаления.", "Предупреждение");
                return;
            }

            try
            {
                Log.Debug("Deleting master: {MasterId}", selectedMaster.MasterId);
                var response = await _mastersClient.DeleteMasterAsync(new DeleteMasterRequest { MasterId = selectedMaster.MasterId });

                if (response.Success)
                {
                    Log.Information("Master deleted successfully");
                    ShowNotification("Мастер успешно удален.", "Успех");
                    await LoadMasters();
                }
                else
                {
                    Log.Warning("Master deletion failed");
                    ShowNotification("Ошибка при удалении мастера.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Master deletion failed");
                ShowNotification($"Ошибка при удалении мастера: {ex.Message}", "Ошибка");
            }
        }

        private async void btnMarkAsDelivered_Click(object sender, EventArgs e)
        {
            Log.Information("Starting order delivery marking");

            if (dgvOrders.SelectedRows.Count == 0)
            {
                Log.Warning("Order delivery marking attempted without selection");
                ShowNotification("Пожалуйста, выберите заказ для выдачи.", "Предупреждение");
                return;
            }

            try
            {
                var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedOrder == null)
                {
                    Log.Warning("Failed to get selected order data");
                    ShowNotification("Не удалось получить данные выбранного заказа.", "Ошибка");
                    return;
                }

                Log.Debug("Marking order as delivered: {OrderId}", selectedOrder.OrderId);
                var orderRequest = new OrderRequest
                {
                    OrderId = selectedOrder.OrderId
                };

                await _ordersClient.MarkOrderAsDeliveredAsync(orderRequest);

                Log.Information("Order marked as delivered successfully");
                ShowNotification("Заказ успешно выдан.", "Успех");
                LoadOrders();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to mark order as delivered");
                ShowNotification("Ошибка при выдаче заказа.", "Ошибка");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            Log.Debug("Searching orders with query: {Query}", searchQuery);
            LoadOrders(searchQuery);
        }

        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using Serilog;

namespace WarehouseClient
{
    public partial class WarehouseForm : Form
    {
        private OrdersService.OrdersServiceClient _ordersClient;
        private bool keyHandled = false;

        public WarehouseForm(OrdersService.OrdersServiceClient ordersClient = null)
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

            Log.Information("Initializing WarehouseForm...");

            this.KeyPreview = true;
            this.KeyUp += WarehouseForm_KeyUp;
            this.KeyDown += WarehouseForm_KeyDown;

            Log.Information("Loading initial data...");
            LoadOrders();
            LoadWarehouseParts();
            InitializeDgvReport();

            Log.Information("WarehouseForm initialized successfully");
        }

        private void InitializeGrpcClient()
        {
            try
            {
                var address = Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS");
                if (string.IsNullOrWhiteSpace(address))
                {
                    throw new InvalidOperationException("GRPC_SERVER_ADDRESS environment variable is not set.");
                }

                var channel = GrpcChannel.ForAddress(address);
                _ordersClient = new OrdersService.OrdersServiceClient(channel);
                Log.Information("gRPC client initialized successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to initialize gRPC client");
                throw;
            }
        }


        private void InitializeDgvReport()
        {
            Log.Debug("Initializing report DataGridView");
            dgvReport.Columns.Clear();
            dgvReport.Columns.Add("Part", "Комплектующее");
            dgvReport.Columns.Add("MissingQuantity", "Недостающее количество");
        }

        private async void LoadOrders()
        {
            txtQuantity.Value = 1;
            try
            {
                Log.Information("Loading orders from server...");
                var request = new GetOrdersRequest { StatusFilter = "" };
                var ordersResponse = await _ordersClient.GetOrdersAsync(request);

                var ordersData = ordersResponse.Orders
                    .Where(order => order.WarehouseRequestStatus == "Заявка отправлена")
                    .Select(order => new
                    {
                        order.CustomerName,
                        order.Status,
                        OrderParts = string.Join(", ", order.Parts.Select(p => $"{p.Name}")),
                        order.OrderId
                    })
                    .ToList();

                dgvOrders.DataSource = ordersData;
                dgvOrders.Columns["CustomerName"].HeaderText = "Имя клиента";
                dgvOrders.Columns["Status"].HeaderText = "Статус заказа";
                dgvOrders.Columns["OrderParts"].HeaderText = "Комплектующие заказа";
                dgvOrders.Columns["OrderId"].Visible = false;

                Log.Information($"Loaded {ordersData.Count} orders");
                UpdateMissingPartsReport();
                dgvOrders.ClearSelection();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error loading orders");
                ShowNotification("Ошибка при загрузке заказов.\nПопытка переподключения через 5 секунд...", "Ошибка");
                await Task.Delay(5000);
                Log.Information("Retrying to load orders...");
                LoadOrders();
            }
        }


        private async void UpdateMissingPartsReport()
        {
            Log.Debug("Updating missing parts report");
            var missingParts = new List<(string PartName, string PartModel, int MissingQuantity, string OrderId)>();

            var request = new GetOrdersRequest { StatusFilter = "Заявка отправлена" };
            var ordersResponse = await _ordersClient.GetOrdersAsync(request);

            foreach (var order in ordersResponse.Orders)
            {
                if (order.WarehouseRequestStatus == "Заявка отправлена")
                {
                    var orderPartsResponse = await _ordersClient.GetOrderPartsAsync(new OrderRequest { OrderId = order.OrderId });

                    foreach (var part in orderPartsResponse.Parts)
                    {
                        var warehousePart = dgvWarehouseParts.Rows.Cast<DataGridViewRow>()
                            .FirstOrDefault(row => row.Cells["Комплектующее"].Value?.ToString() == part.Name &&
                                                   row.Cells["Модель"].Value?.ToString() == part.Model);

                        if (warehousePart == null || (int)warehousePart.Cells["Количество"].Value < part.Quantity)
                        {
                            int missingQuantity = part.Quantity - (warehousePart?.Cells["Количество"].Value as int? ?? 0);
                            missingParts.Add((part.Name, part.Model, missingQuantity, order.OrderId.ToString()));
                            Log.Debug($"Missing part detected: {part.Name} ({part.Model}), missing: {missingQuantity}");
                        }
                    }
                }
            }

            ShowMissingPartsReport(missingParts);
            dgvReport.ClearSelection();
            Log.Information($"Missing parts report updated with {missingParts.Count} entries");
        }

        private void ShowMissingPartsReport(List<(string PartName, string PartModel, int MissingQuantity, string OrderId)> missingParts)
        {
            dgvReport.Rows.Clear();

            foreach (var (PartName, PartModel, MissingQuantity, OrderId) in missingParts.Distinct())
            {
                var rowIndex = dgvReport.Rows.Add($"{PartName} ({PartModel})", MissingQuantity);
                dgvReport.Rows[rowIndex].Cells["Part"].Tag = OrderId;
            }

            dgvReport.Refresh();
        }

        private void ShowNotification(string message, string type)
        {
            Log.Information($"Showing notification: {type} - {message}");
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

        private async void BtnAddPartToWarehouse_Click(object sender, EventArgs e)
        {
            Log.Information("Add part to warehouse button clicked");
            if (string.IsNullOrEmpty(txtPartName.Text) ||
                string.IsNullOrEmpty(txtPartModel.Text) ||
                !double.TryParse(txtPartPrice.Text, out var price) ||
                !int.TryParse(txtQuantity.Text, out var quantity))
            {
                Log.Warning("Invalid input data for adding part");
                ShowNotification("Введите корректные данные: название, модель, количество и цену.", "Предупреждение");
                return;
            }

            try
            {
                var existingPart = dgvWarehouseParts.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(row => row.Cells["Комплектующее"].Value?.ToString() == txtPartName.Text &&
                                           row.Cells["Модель"].Value?.ToString() == txtPartModel.Text);

                if (existingPart != null)
                {
                    Log.Information($"Updating existing part: {txtPartName.Text} ({txtPartModel.Text})");
                    var existingQuantity = (int)existingPart.Cells["Количество"].Value;
                    existingPart.Cells["Количество"].Value = existingQuantity + quantity;
                    existingPart.Cells["Цена"].Value = price;

                    var updateRequest = new AddPartsRequest
                    {
                        PartName = txtPartName.Text,
                        Model = txtPartModel.Text,
                        Quantity = quantity,
                        Price = price
                    };
                    await _ordersClient.AddPartsToWarehouseAsync(updateRequest);

                    Log.Information($"Part {txtPartName.Text} ({txtPartModel.Text}) quantity updated by {quantity}");
                    ShowNotification("Количество комплектующего обновлено на складе.", "Успех");
                }
                else
                {
                    Log.Information($"Adding new part: {txtPartName.Text} ({txtPartModel.Text})");
                    var request = new AddPartsRequest
                    {
                        PartName = txtPartName.Text,
                        Model = txtPartModel.Text,
                        Quantity = quantity,
                        Price = price
                    };
                    await _ordersClient.AddPartsToWarehouseAsync(request);

                    Log.Information($"New part added: {txtPartName.Text} ({txtPartModel.Text}), quantity: {quantity}, price: {price}");
                    ShowNotification("Комплектующие добавлены на склад.", "Успех");
                }

                LoadWarehouseParts();

                txtPartName.Clear();
                txtPartModel.Clear();
                txtPartPrice.Clear();
                txtQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding parts to warehouse");
                ShowNotification("Ошибка добавления комплектующих", "Ошибка");
            }
        }


        private async void LoadWarehouseParts()
        {
            Log.Information("Loading warehouse parts...");
            try
            {
                var response = await _ordersClient.GetWarehousePartsAsync(new Empty());

                var warehouseParts = response.Parts.Select(p => new
                {
                    Комплектующее = p.Name,
                    Модель = p.Model,
                    Количество = p.Quantity,
                    Цена = p.Price
                }).ToList();

                if (warehouseParts.Any())
                {
                    dgvWarehouseParts.DataSource = warehouseParts;
                    dgvWarehouseParts.Refresh();
                    Log.Information($"Loaded {warehouseParts.Count} warehouse parts");
                }
                else
                {
                    Log.Warning("No parts found in warehouse");
                    ShowNotification("На складе нет комплектующих.", "Предупреждение");
                }
                dgvWarehouseParts.ClearSelection();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error loading warehouse parts");
                ShowNotification($"Ошибка загрузки комплектующих со склада: {ex.Message}", "Ошибка");
            }
        }

        private void WarehouseForm_KeyUp(object sender, KeyEventArgs e)
        {
            keyHandled = false;
        }

        private void WarehouseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyHandled) return;

            if (e.KeyCode == Keys.Escape)
            {
                Log.Debug("ESC key pressed - clearing selections");
                dgvOrders.ClearSelection();
                dgvReport.ClearSelection();
                dgvWarehouseParts.ClearSelection();
                txtPartModel.Text = "";
                txtPartName.Text = "";
                txtPartPrice.Text = "";
                txtQuantity.Value = 0;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                Log.Debug("F5 key pressed - refreshing data");
                keyHandled = true;
                LoadOrders();
                LoadWarehouseParts();
                e.Handled = true;
            }
        }


        private void ExportMissingPartsToExcel()
        {
            Log.Information("Exporting missing parts to Excel");
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Отчет недостающих комплектующих");

                    worksheet.Cell(1, 1).Value = "Имя клиента";
                    worksheet.Cell(1, 2).Value = "Комплектующие заказа";
                    worksheet.Cell(1, 3).Value = "Недостающее комплектующее";
                    worksheet.Cell(1, 4).Value = "Недостающее количество";

                    int row = 2;

                    foreach (DataGridViewRow orderRow in dgvOrders.Rows)
                    {
                        string customerName = orderRow.Cells["CustomerName"].Value?.ToString();
                        string orderParts = orderRow.Cells["OrderParts"].Value?.ToString();
                        string orderId = orderRow.Cells["OrderId"].Value?.ToString();

                        var missingParts = dgvReport.Rows
                            .Cast<DataGridViewRow>()
                            .Where(missingRow =>
                                missingRow.Cells["Part"].Tag?.ToString() == orderId)
                            .Select(missingRow => new
                            {
                                Part = missingRow.Cells["Part"].Value?.ToString(),
                                Quantity = missingRow.Cells["MissingQuantity"].Value?.ToString()
                            })
                            .ToList();

                        bool isFirstRow = true;

                        foreach (var part in missingParts)
                        {
                            worksheet.Cell(row, 1).Value = isFirstRow ? customerName : "";
                            worksheet.Cell(row, 2).Value = isFirstRow ? orderParts : "";
                            worksheet.Cell(row, 3).Value = part.Part;
                            worksheet.Cell(row, 4).Value = part.Quantity;
                            isFirstRow = false;
                            row++;
                        }

                        if (!missingParts.Any())
                        {
                            worksheet.Cell(row, 1).Value = customerName;
                            worksheet.Cell(row, 2).Value = orderParts;
                            worksheet.Cell(row, 3).Value = "-";
                            worksheet.Cell(row, 4).Value = "-";
                            row++;
                        }
                    }

                    worksheet.Columns().AdjustToContents();

                    var saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel файлы (*.xlsx)|*.xlsx",
                        Title = "Сохранить отчет",
                        FileName = "Отчет недостающих комплектующих.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        Log.Information($"Report saved to {saveFileDialog.FileName}");
                        ShowNotification("Отчет успешно сохранен.", "Успех");
                    }
                    else
                    {
                        Log.Information("Report export cancelled by user");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error exporting report to Excel");
                ShowNotification($"Ошибка при сохранении отчета: {ex.Message}", "Ошибка");
            }
        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportMissingPartsToExcel();
        }

        private async void BtnDeletePart_Click(object sender, EventArgs e)
        {
            Log.Information("Delete part button clicked");
            if (dgvWarehouseParts.CurrentRow == null)
            {
                Log.Warning("No part selected for deletion");
                ShowNotification("Выберите комплектующее для удаления.", "Предупреждение");
                return;
            }

            string partName = dgvWarehouseParts.CurrentRow.Cells["Комплектующее"].Value?.ToString();
            string partModel = dgvWarehouseParts.CurrentRow.Cells["Модель"].Value?.ToString();

            if (string.IsNullOrEmpty(partName) || string.IsNullOrEmpty(partModel))
            {
                Log.Error("Invalid part data for deletion");
                ShowNotification("Ошибка получения данных комплектующего.", "Ошибка");
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Удалить комплектующее \"{partName} ({partModel})\"?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Log.Information($"Deleting part: {partName} ({partModel})");
                    var request = new DeletePartRequest
                    {
                        PartName = partName,
                        Model = partModel
                    };
                    await _ordersClient.DeletePartFromWarehouseAsync(request);

                    Log.Information($"Part {partName} ({partModel}) deleted successfully");
                    ShowNotification("Комплектующее удалено.", "Успех");

                    // Очищаем DataSource перед загрузкой
                    dgvWarehouseParts.DataSource = null;
                    dgvWarehouseParts.Rows.Clear();
                    dgvWarehouseParts.Refresh();

                    // Перезагружаем данные
                    LoadWarehouseParts();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error deleting part {partName} ({partModel})");
                    ShowNotification($"Ошибка удаления: {ex.Message}", "Ошибка");
                }
            }
            else
            {
                Log.Information("Deletion cancelled by user");
            }
            txtPartName.Clear();
            txtPartModel.Clear();
            txtPartPrice.Clear();
            txtQuantity.Value = 1;
        }
        private void dgvWarehouseParts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvWarehouseParts.Rows[e.RowIndex];

                txtPartName.Text = row.Cells["Комплектующее"].Value?.ToString();
                txtPartModel.Text = row.Cells["Модель"].Value?.ToString();
                txtPartPrice.Text = row.Cells["Цена"].Value?.ToString();
            }
        }
    }
}
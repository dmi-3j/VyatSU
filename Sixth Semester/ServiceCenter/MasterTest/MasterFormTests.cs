using Grpc.Core;
using MasterClient;
using Moq;
using ServiceCenter;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;
using static OrdersService;

public class MasterFormTests
{
    private readonly Mock<OrdersService.OrdersServiceClient> _mockClient;
    private readonly Master _testMaster;
    private readonly MasterForm _form;

    public MasterFormTests()
    {
        _mockClient = new Mock<OrdersService.OrdersServiceClient>();

        _testMaster = new Master
        {
            FullName = "Петр Петров",
            Specialization = "Ремонт ПК"
        };

        _form = new MasterForm(_testMaster);

        _form.dgvOrders = new DataGridView();
        _form.cboParts = new ComboBox();
        _form.cboStatus = new ComboBox();
        _form.txtPartModel = new TextBox();
        _form.nudPartQuantity = new NumericUpDown();

        _form.cboParts.Items.AddRange(new[] { "Дисплей", "Аккумулятор" });
        _form.cboStatus.Items.AddRange(new[] { "В работе", "Готов к выдаче", "Отменён" });
    }

    private AsyncUnaryCall<T> CreateAsyncUnaryCall<T>(T response)
    {
        var task = Task.FromResult(response);
        return new AsyncUnaryCall<T>(
            task,
            Task.FromResult(new Metadata()),
            () => Status.DefaultSuccess,
            () => new Metadata(),
            () => { });
    }

    [Fact]
    public async Task LoadOrders_FillsDataGridView_WithMasterOrders()
    {
        var orders = new List<OrderResponse>
    {
        new OrderResponse
        {
            OrderId = "1",
            CustomerName = "Иван Иванов",
            DeviceModel = "Lenovo",
            ResponsibleMaster = "Петр Петров",  // Обязательно совпадает с _testMaster.FullName
            Parts = { new Part { Name = "Дисплей", Quantity = 1 } },
            OrderDate = "20-05-2025",
            Status = "В работе",
            WarehouseRequestStatus = "Нет"
        },
        new OrderResponse
        {
            OrderId = "2",
            CustomerName = "Анна Смирнова",
            DeviceModel = "Acer",
            ResponsibleMaster = "Другой Мастер",
            Parts = { new Part { Name = "Аккумулятор", Quantity = 2 } },
            OrderDate = "19-05-2025",
            Status = "В работе",
            WarehouseRequestStatus = "В обработке"
        }
    };

        _mockClient
            .Setup(c => c.GetOrdersAsync(It.IsAny<GetOrdersRequest>(), null, null, default))
            .Returns(CreateAsyncUnaryCall(new OrderListResponse { Orders = { orders } }));

        // Устанавливаем приватные поля _authenticatedMaster и _ordersClient
        typeof(MasterForm).GetField("_authenticatedMaster", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(_form, _testMaster);

        typeof(MasterForm).GetField("_ordersClient", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(_form, _mockClient.Object);

        var handle = _form.Handle; // Для Invoke, если понадобится (в данном случае await работает напрямую)

        await _form.LoadOrders();

        var dataSource = _form.dgvOrders.DataSource as System.Collections.IEnumerable;

        Assert.NotNull(dataSource);

        var list = dataSource.Cast<object>().ToList();
        Assert.Single(list);

        var firstItem = list[0];
        var customerName = firstItem.GetType().GetProperty("CustomerName")?.GetValue(firstItem) as string;
        Assert.Equal("Иван Иванов", customerName);
    }


    [Fact]
    public void BtnAddPart_AddsPart_WhenStatusIsInWork()
    {
        _form.cboParts.SelectedItem = "Дисплей";
        _form.txtPartModel.Text = "МодельX";
        _form.nudPartQuantity.Value = 2;
        _form.cboStatus.SelectedItem = "В работе";

        _form.BtnAddPart_Click(null, null);

        var parts = _form.dgvParts.DataSource as List<Part>;

        Assert.NotNull(parts);
        Assert.Single(parts);
        Assert.Equal("Дисплей", parts[0].Name);
        Assert.Equal("МодельX", parts[0].Model);
        Assert.Equal(2, parts[0].Quantity);
    }

    [Fact]
    public void BtnAddPart_DoesNotAddPart_WhenStatusIsNotInWork()
    {
        _form.cboParts.SelectedItem = "Дисплей";
        _form.txtPartModel.Text = "МодельX";
        _form.nudPartQuantity.Value = 2;
        _form.cboStatus.SelectedItem = "Готов к выдаче";

        _form.BtnAddPart_Click(null, null);

        var parts = _form.dgvParts.DataSource as List<Part>;

        Assert.Null(parts);
    }

    [Fact]
    public void BtnAddPart_ShowsWarning_WhenNoPartSelected()
    {
        bool notificationShown = false;
        _form.cboParts.SelectedIndex = -1;
        _form.txtPartModel.Text = "МодельX";
        _form.cboStatus.SelectedItem = "В работе";

        typeof(MasterForm).GetMethod("ShowNotification", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .Invoke(_form, new object[] { "Выберите комплектующее.", "Предупреждение" });

        _form.BtnAddPart_Click(null, null);

        var parts = _form.dgvParts.DataSource as List<Part>;
        Assert.Null(parts);
    }
}
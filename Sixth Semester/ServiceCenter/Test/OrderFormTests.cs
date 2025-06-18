using Xunit;
using Moq;
using Grpc.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using static OrdersService;
using OrderClient;

public class OrderFormTests
{
    private readonly Mock<OrdersServiceClient> _mockClient;
    private readonly OrderForm _form;

    public OrderFormTests()
    {
        _mockClient = new Mock<OrdersServiceClient>();

        _form = new OrderForm(_mockClient.Object);

        _form.txtCustomerName = new TextBox();
        _form.txtDeviceModel = new TextBox();
        _form.txtDescription = new TextBox();
        _form.txtPhoneNumber = new MaskedTextBox();
        _form.txtPrice = new TextBox();

        _form.typeRepairCmb = new ComboBox();
        _form.deviceTypeCmb = new ComboBox();
        _form.dgvOrders = new DataGridView();

        _form.deviceTypeCmb.Items.Add("ПК");
        _form.typeRepairCmb.Items.Add("Замена комплектующих");
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
    public async Task LoadOrders_FillsDataGridView()
    {
        var orders = new List<OrderResponse>
        {
            new OrderResponse
            {
                OrderId = "1",
                CustomerName = "Иван Иванов",
                DeviceModel = "Lenovo",
                Parts = { new Part { Name = "Дисплей", Quantity = 1 } }
            }
        };

        _mockClient
            .Setup(c => c.GetOrdersAsync(It.IsAny<GetOrdersRequest>(), null, null, default))
            .Returns(CreateAsyncUnaryCall(new OrderListResponse { Orders = { orders } }));

        await _form.LoadOrders("");

        var dataSource = _form.dgvOrders.DataSource as System.Collections.IList;

        Assert.NotNull(dataSource);
        Assert.True(dataSource.Count > 0);

        var firstItem = dataSource[0];
        var customerName = firstItem.GetType().GetProperty("CustomerName")?.GetValue(firstItem) as string;

        Assert.Equal("Иван Иванов", customerName);
    }

    [Fact]
    public async Task LoadOrders_EmptyList_ClearsDataGrid()
    {
        _mockClient
            .Setup(c => c.GetOrdersAsync(It.IsAny<GetOrdersRequest>(), null, null, default))
            .Returns(CreateAsyncUnaryCall(new OrderListResponse()));

        await _form.LoadOrders("");

        var dataSource = _form.dgvOrders.DataSource as System.Collections.IList;

        Assert.NotNull(dataSource);
        Assert.Empty(dataSource);
    }

    [Fact]
    public async Task CreateOrder_DoesNotCallGrpc_WhenFieldsEmpty()
    {
        _form.txtCustomerName.Text = "";
        _form.txtDeviceModel.Text = "";
        _form.txtDescription.Text = "";
        _form.txtPhoneNumber.Text = "";
        _form.txtPrice.Text = "";

        await _form.btnCreateOrder_Click(null, null);

        _mockClient.Verify(c => c.CreateOrderAsync(It.IsAny<OrderRequest>(), null, null, default), Times.Never);
    }

    [Fact]
    public async Task CreateOrder_CallsGrpc_WhenFieldsAreValid()
    {
        _form.txtCustomerName.Text = "Иван Петров";
        _form.txtDeviceModel.Text = "HP Pavilion";
        _form.txtDescription.Text = "Не включается";
        _form.txtPhoneNumber.Text = "89991112233";
        _form.txtPrice.Text = "5000";
        _form.deviceTypeCmb.SelectedItem = "ПК";
        _form.typeRepairCmb.SelectedItem = "Замена комплектующих";

        _mockClient
            .Setup(c => c.CreateOrderAsync(It.IsAny<OrderRequest>(), null, null, default))
            .Returns(CreateAsyncUnaryCall(new OrderResponse { OrderId = "123" }));

        await _form.btnCreateOrder_Click(null, null);

        _mockClient.Verify(c => c.CreateOrderAsync(It.Is<OrderRequest>(r =>
            r.CustomerName == "Иван Петров" &&
            r.DeviceModel == "HP Pavilion" &&
            r.Description == "Не включается" &&
            r.PhoneNumber == "89991112233" &&
            r.Price == 5000 &&
            r.DeviceType == "ПК" 
        ), null, null, default), Times.Once);
    }

    [Fact]
    public async Task CreateOrder_DoesNotCallGrpc_WhenPriceIsInvalid()
    {
        _form.txtCustomerName.Text = "Тест";
        _form.txtDeviceModel.Text = "Asus";
        _form.txtDescription.Text = "Описание";
        _form.txtPhoneNumber.Text = "89000000000";
        _form.txtPrice.Text = "не число";
        _form.deviceTypeCmb.SelectedItem = "ПК";
        _form.typeRepairCmb.SelectedItem = "Замена комплектующих";

        await _form.btnCreateOrder_Click(null, null);

        _mockClient.Verify(c => c.CreateOrderAsync(It.IsAny<OrderRequest>(), null, null, default), Times.Never);
    }
}

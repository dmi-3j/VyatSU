using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using ServiceCenter.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

public class StatusModel : PageModel
{
    private readonly OrdersService.OrdersServiceClient _ordersServiceClient;

    public StatusModel(OrdersService.OrdersServiceClient ordersServiceClient)
    {
        _ordersServiceClient = ordersServiceClient;
    }

    public List<OrderResponse> Orders { get; set; } = new List<OrderResponse>();

    [BindProperty(SupportsGet = true)]
    public string PhoneNumber { get; set; }

    public async Task OnGetAsync()
    {
        if (!string.IsNullOrEmpty(PhoneNumber))
        {
            try
            {
                Log.Information("Starting order search for phone: {PhoneNumber}", PhoneNumber);
                var request = new GetOrdersRequest { StatusFilter = "Все", SearchQuery = PhoneNumber };
                Log.Debug("Sending gRPC request: {@Request}", request);
                var ordersResponse = await _ordersServiceClient.GetOrdersAsync(request);


                Log.Debug("Received gRPC response with {OrderCount} orders",
                    ordersResponse.Orders.Count);
                Orders = ordersResponse.Orders
                    .OrderByDescending(о => о.OrderDate)
                    .ToList();
            }
            catch (RpcException ex)
            {
                Log.Error(ex, "gRPC error while fetching orders for phone: {PhoneNumber}. Status: {Status}",
                    PhoneNumber, ex.Status);
                ViewData["Error"] = "Ошибка при запросе данных: " + ex.Message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error while processing request for phone: {PhoneNumber}",
                    PhoneNumber);
                ViewData["Error"] = "Произошла непредвиденная ошибка";
            }
        }
    }
    [HttpGet("api/orders")]
    public async Task<JsonResult> GetOrdersApi(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
        {
            return new JsonResult(new { success = false, error = "Phone number is required" })
            {
                StatusCode = 400
            };
        }

        try
        {
            var request = new GetOrdersRequest { StatusFilter = "Все", SearchQuery = phoneNumber };
            var ordersResponse = await _ordersServiceClient.GetOrdersAsync(request);

            var result = new
            {
                success = true,
                orders = ordersResponse.Orders
                    .OrderByDescending(o => o.OrderDate)
                    .Select(o => new
                    {
                        orderDate = o.OrderDate,
                        status = o.Status,
                        deviceType = o.DeviceType,
                        deviceModel = o.DeviceModel,
                        repairType = o.RepairType
                    })
            };

            return new JsonResult(result);
        }
        catch (Exception ex)
        {
            return new JsonResult(new { success = false, error = ex.Message })
            {
                StatusCode = 500
            };
        }
    }
}

using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersService.OrdersServiceClient _ordersServiceClient;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(
            OrdersService.OrdersServiceClient ordersServiceClient,
            ILogger<OrdersController> logger)
        {
            _ordersServiceClient = ordersServiceClient;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return BadRequest(new { success = false, error = "Phone number is required" });
            }

            try
            {
                _logger.LogInformation("API: Starting order search for phone: {PhoneNumber}", phoneNumber);
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

                _logger.LogDebug("API: Successfully processed request for phone: {PhoneNumber}", phoneNumber);
                return Ok(result);
            }
            catch (RpcException ex)
            {
                _logger.LogError(ex, "API: gRPC error for phone: {PhoneNumber}. Status: {Status}",
                    phoneNumber, ex.Status);
                return StatusCode(500, new { success = false, error = "Service unavailable" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "API: Unexpected error for phone: {PhoneNumber}", phoneNumber);
                return StatusCode(500, new { success = false, error = "Internal server error" });
            }
        }
    }
}

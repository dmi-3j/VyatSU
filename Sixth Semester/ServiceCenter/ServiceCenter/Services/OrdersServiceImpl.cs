using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using OpenTelemetry.Context.Propagation;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using Serilog;
using OpenTelemetry;
using ServiceCenter.Classes;
using ServiceCenter.DB;
using Microsoft.EntityFrameworkCore.Query;

namespace ServiceCenter.Services
{
    public class OrdersServiceImpl : OrdersService.OrdersServiceBase
    {
        private static readonly ActivitySource ActivitySource = new("ServiceCenter.Orders");
        private static readonly TextMapPropagator Propagator = Propagators.DefaultTextMapPropagator;
        private readonly AppDbContext _dbContext;

        public OrdersServiceImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public OrdersServiceImpl()
        {
        }

        #region Order Operations

        public override async Task<OrderResponse> CreateOrder(OrderRequest request, ServerCallContext context)
        {
            using var activity = ActivitySource.StartActivity("CreateOrder", ActivityKind.Server);
            activity?.SetTag("order.customer", request.CustomerName);
            activity?.SetTag("order.device", $"{request.DeviceType} {request.DeviceModel}");
            activity?.SetTag("order.repair_type", request.RepairType);
            activity?.SetTag("order.parts_count", request.Parts.Count);

            try
            {
                using (var createActivity = ActivitySource.StartActivity("CreateOrderInternal"))
                {
                    var order = await CreateOrderInternal(request);
                    createActivity?.SetTag("order.id", order.OrderId);

                    using (var saveActivity = ActivitySource.StartActivity("SaveOrderToDatabase"))
                    {
                        await SaveOrderToDatabase(order);
                        saveActivity?.SetTag("db.operation", "insert");
                    }

                    using (var queueActivity = ActivitySource.StartActivity("SendToQueue"))
                    {
                        SendOrderToQueue(order);
                        queueActivity?.SetTag("queue.name", "orders_queue");
                    }

                    activity?.SetTag("order.status", order.Status);
                    Log.Information("Order created successfully. ID: {OrderId}", order.OrderId);
                    return MapToOrderResponse(order);
                }
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                Log.Error(ex, "Order creation failed");
                throw;
            }
        }

        public override async Task<OrderResponse> UpdateOrder(OrderRequest request, ServerCallContext context)
        {
            using var activity = ActivitySource.StartActivity("UpdateOrder", ActivityKind.Server);
            activity?.SetTag("order.id", request.OrderId);

            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                using (var findActivity = ActivitySource.StartActivity("FindOrder"))
                {
                    var order = await FindOrderWithTracking(request.OrderId);
                    findActivity?.SetTag("order.found", order != null);

                    if (order == null)
                    {
                        Log.Warning("Order not found: {OrderId}", request.OrderId);
                        return new OrderResponse { OrderId = request.OrderId };
                    }

                    activity?.SetTag("order.old_status", order.Status);

                    using (var updateActivity = ActivitySource.StartActivity("UpdateOrderData"))
                    {
                        UpdateOrderData(order, request);
                        updateActivity?.SetTag("fields_updated", 7);
                    }

                    using (var partsActivity = ActivitySource.StartActivity("UpdateOrderParts"))
                    {
                        await UpdateOrderParts(order, request.Parts);
                        partsActivity?.SetTag("parts.updated", order.Parts.Count);
                    }

                    using (var saveActivity = ActivitySource.StartActivity("CommitTransaction"))
                    {
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                        saveActivity?.SetTag("db.operation", "update");
                    }

                    activity?.SetTag("order.new_status", order.Status);
                    Log.Information("Order updated: {OrderId}", order.OrderId);
                    return MapToOrderResponse(order);
                }
            }
            catch (Exception ex)
            {
                using var rollbackActivity = ActivitySource.StartActivity("RollbackTransaction");
                await transaction.RollbackAsync();
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                Log.Error(ex, "Order update failed");
                throw;
            }
        }

        public override async Task<OrderResponse> DeleteOrder(OrderRequest request, ServerCallContext context)
        {
            using var activity = ActivitySource.StartActivity("DeleteOrder", ActivityKind.Server);
            activity?.SetTag("order.id", request.OrderId);

            try
            {
                using (var findActivity = ActivitySource.StartActivity("FindOrder"))
                {
                    var order = await FindOrderWithTracking(request.OrderId);
                    findActivity?.SetTag("order.found", order != null);

                    if (order == null)
                    {
                        Log.Warning("Order not found: {OrderId}", request.OrderId);
                        return new OrderResponse { OrderId = request.OrderId };
                    }

                    using (var deleteActivity = ActivitySource.StartActivity("DeleteFromDatabase"))
                    {
                        _dbContext.Orders.Remove(order);
                        await _dbContext.SaveChangesAsync();
                        deleteActivity?.SetTag("db.operation", "delete");
                    }

                    using (var notifyActivity = ActivitySource.StartActivity("SendDeletionNotification"))
                    {
                        notifyActivity?.SetTag("notification.sent", false);
                    }

                    activity?.SetTag("order.deleted", true);
                    Log.Information("Order deleted: {OrderId}", order.OrderId);
                    return new OrderResponse { OrderId = request.OrderId };
                }
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                Log.Error(ex, "Order deletion failed");
                throw;
            }
        }

        #endregion

        #region Support Methods with Tracing

        private async Task<Order> CreateOrderInternal(OrderRequest request)
        {
            using var activity = ActivitySource.StartActivity("CreateOrderInternal");
            activity?.SetTag("order.operation", "creation");

            var orderId = Guid.NewGuid().ToString();
            Log.Information("Creating new order [ID: {OrderId}] for customer: {Customer}",
                orderId, request.CustomerName);

            var order = new Order
            {
                OrderId = orderId,
                CustomerName = request.CustomerName,
                PhoneNumber = request.PhoneNumber,
                DeviceType = request.DeviceType,
                DeviceModel = request.DeviceModel,
                RepairType = request.RepairType,
                Description = request.Description,
                Status = "Принят",
                WarehouseRequestStatus = "",
                OrderDate = DateTime.Now.ToString("dd-MM-yyyy"),
                ResponsibleMaster = request.ResponsibleMaster,
                Price = request.Price
            };

            using (var partsActivity = ActivitySource.StartActivity("AddPartsToOrder"))
            {
                foreach (var part in request.Parts)
                {
                    order.Parts.Add(new OrderPart
                    {
                        Name = part.Name,
                        Quantity = part.Quantity,
                        Model = part.Model
                    });
                }
                partsActivity?.SetTag("parts.added", request.Parts.Count);
            }

            return order;
        }

        private async Task<Order> FindOrderWithTracking(string orderId)
        {
            using var activity = ActivitySource.StartActivity("FindOrderWithTracking");
            activity?.SetTag("order.id", orderId);

            var order = await _dbContext.Orders
                .Include(o => o.Parts)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            activity?.SetTag("order.found", order != null);
            return order;
        }

        private void UpdateOrderData(Order order, OrderRequest request)
        {
            using var activity = ActivitySource.StartActivity("UpdateOrderData");
            activity?.SetTag("fields.updated", 7);

            order.PhoneNumber = request.PhoneNumber;
            order.DeviceType = request.DeviceType;
            order.DeviceModel = request.DeviceModel;
            order.RepairType = request.RepairType;
            order.Description = request.Description;
            order.Status = request.Status;
            order.ResponsibleMaster = request.ResponsibleMaster;
            order.Price = request.Price;
        }

        private async Task UpdateOrderParts(Order order, IEnumerable<Part> parts)
        {
            using var activity = ActivitySource.StartActivity("UpdateOrderParts");
            var existingParts = order.Parts.ToList();
            int updatedCount = 0, addedCount = 0;

            foreach (var part in parts)
            {
                var existingPart = existingParts.FirstOrDefault(p => p.Name == part.Name);
                if (existingPart != null)
                {
                    existingPart.Quantity = part.Quantity;
                    existingPart.Model = part.Model;
                    updatedCount++;
                }
                else
                {
                    order.Parts.Add(new OrderPart
                    {
                        Name = part.Name,
                        Quantity = part.Quantity,
                        Model = part.Model
                    });
                    addedCount++;
                }
            }

            activity?.SetTag("parts.updated", updatedCount);
            activity?.SetTag("parts.added", addedCount);
        }

        private async Task SaveOrderToDatabase(Order order)
        {
            using var activity = ActivitySource.StartActivity("SaveOrderToDatabase");
            try
            {
                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();
                activity?.SetTag("db.operation", "insert");
                Log.Information("Order saved successfully. ID: {OrderId}", order.OrderId);
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                Log.Error(ex, "Failed to save order {OrderId}", order.OrderId);
                throw;
            }
        }

        public void SendOrderToQueue(Order order)
        {
            using var activity = ActivitySource.StartActivity("SendOrderToQueue");
            activity?.SetTag("queue.name", "orders_queue");
            activity?.SetTag("order.id", order.OrderId);

            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST"),
                    Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? "5672"),
                    UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME"),
                    Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD"),
                    VirtualHost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST"),
                    AutomaticRecoveryEnabled = true
                };

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                {
                    channel.QueueDeclare(
                        queue: "orders_queue",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var message = JsonConvert.SerializeObject(order);
                    var body = Encoding.UTF8.GetBytes(message);

                    var props = channel.CreateBasicProperties();

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "orders_queue",
                        basicProperties: props,
                        body: body);

                    activity?.SetTag("message.sent", true);
                    Log.Debug("Order sent to queue: {OrderId}", order.OrderId);
                }
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                Log.Error(ex, "Failed to send order to queue");
            }
        }

        #endregion

        #region Other Methods with Tracing

        public override async Task<OrderListResponse> GetOrders(GetOrdersRequest request, ServerCallContext context)
        {
            using var activity = ActivitySource.StartActivity("GetOrders", ActivityKind.Server);
            activity?.SetTag("filter.status", request.StatusFilter);
            activity?.SetTag("filter.search", request.SearchQuery ?? "null");

            try
            {
                using (var queryActivity = ActivitySource.StartActivity("BuildQuery"))
                {
                    IQueryable<Order> query = _dbContext.Orders.Include(o => o.Parts);

                    if (request.StatusFilter == "Готов к выдаче")
                    {
                        query = query.Where(order => order.Status == "Готов к выдаче");
                    }
                    else if (request.StatusFilter == "Выдан")
                    {
                        query = query.Where(order => order.Status == "Выдан");
                    }
                    else if (request.StatusFilter != "Все")
                    {
                        query = query.Where(order => order.Status != "Готов к выдаче" && order.Status != "Выдан");
                    }
                    else if (request.StatusFilter.Equals("Все") && request.SearchQuery != null)
                    {
                        query = query.Where(order => order.PhoneNumber.Contains(request.SearchQuery));
                    }

                    var orders = await query.ToListAsync();
                    activity?.SetTag("orders.count", orders.Count);

                    var response = new OrderListResponse();
                    foreach (var order in orders)
                    {
                        response.Orders.Add(MapToOrderResponse(order));
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                Log.Error(ex, "Failed to get orders");
                throw;
            }
        }

        public override async Task<OrderPartsResponse> GetOrderParts(OrderRequest request, ServerCallContext context)
        {
            using var activity = ActivitySource.StartActivity("GetOrderParts", ActivityKind.Server);
            activity?.SetTag("order.id", request.OrderId);

            try
            {
                using (var findActivity = ActivitySource.StartActivity("FindOrder"))
                {
                    var order = await _dbContext.Orders
                        .Include(o => o.Parts)
                        .FirstOrDefaultAsync(o => o.OrderId == request.OrderId);

                    if (order == null)
                    {
                        activity?.SetTag("order.found", false);
                        throw new RpcException(new Status(StatusCode.NotFound, $"Order with ID {request.OrderId} not found"));
                    }

                    activity?.SetTag("parts.count", order.Parts.Count);
                    var response = new OrderPartsResponse();
                    response.Parts.AddRange(order.Parts.Select(p => new Part
                    {
                        Name = p.Name,
                        Model = p.Model,
                        Quantity = p.Quantity
                    }));

                    return response;
                }
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                Log.Error(ex, "Failed to get order parts");
                throw;
            }
        }

        public override async Task<OrderResponse> UpdateWarehouseRequestStatus(OrderRequest request, ServerCallContext context)
        {
            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.OrderId == request.OrderId);

            if (order == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Заказ не найден"));

            if (request.WarehouseRequestStatus != "Заявка отправлена")
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Можно установить только статус 'Заявка отправлена'"));

            order.WarehouseRequestStatus = request.WarehouseRequestStatus;
            await _dbContext.SaveChangesAsync();

            return MapToOrderResponse(order);
        }

        public override async Task<OrderResponse> ProcessWarehouseRequest(OrderRequest request, ServerCallContext context)
        {
            var order = await _dbContext.Orders
                .Include(o => o.Parts)
                .FirstOrDefaultAsync(o => o.OrderId == request.OrderId);

            if (order == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Заказ не найден"));

            if (order.WarehouseRequestStatus != "Заявка отправлена")
                throw new RpcException(new Status(StatusCode.FailedPrecondition, "Сначала отправьте заявку на склад"));

            var missingParts = new List<string>();
            double totalPrice = 0;

            foreach (var part in order.Parts)
            {
                var warehousePart = await _dbContext.WarehouseParts
                    .FirstOrDefaultAsync(w => w.Name == part.Name && w.Model == part.Model);

                if (warehousePart == null || warehousePart.Quantity < part.Quantity)
                    missingParts.Add($"{part.Name} (Нужно: {part.Quantity}, Есть: {warehousePart?.Quantity ?? 0})");
                else
                    totalPrice += warehousePart.Price * part.Quantity;
            }

            if (missingParts.Any())
                throw new RpcException(new Status(StatusCode.ResourceExhausted,
                    $"Не хватает деталей: {string.Join(", ", missingParts)}"));

            foreach (var part in order.Parts)
            {
                var warehousePart = await _dbContext.WarehouseParts
                    .FirstOrDefaultAsync(w => w.Name == part.Name && w.Model == part.Model);

                warehousePart!.Quantity -= part.Quantity;
            }

            order.Price += totalPrice;
            order.WarehouseRequestStatus = "Комплектующие выданы";
            await _dbContext.SaveChangesAsync();

            return MapToOrderResponse(order);
        }

        public override async Task<WarehousePartsResponse> GetWarehouseParts(Empty request, ServerCallContext context)
        {
            Log.Debug("Fetching all warehouse parts");

            var response = new WarehousePartsResponse();
            var parts = await _dbContext.WarehouseParts.ToListAsync();

            Log.Information("Found {PartCount} warehouse parts", parts.Count);
            foreach (var part in parts)
            {
                response.Parts.Add(new Part
                {
                    Name = part.Name,
                    Model = part.Model,
                    Quantity = part.Quantity,
                    Price = part.Price
                });
            }

            return response;
        }

        public override async Task<Empty> AddPartsToWarehouse(AddPartsRequest request, ServerCallContext context)
        {
            Log.Information("Adding parts to warehouse. Part: {PartName}, Qty: {Quantity}",
                request.PartName, request.Quantity);

            var existingPart = await _dbContext.WarehouseParts
                .FirstOrDefaultAsync(p => p.Name == request.PartName && p.Model == request.Model);

            if (existingPart != null)
            {
                Log.Debug("Updating existing warehouse part. Old Qty: {OldQuantity}, New Qty: {NewQuantity}",
                    existingPart.Quantity, existingPart.Quantity + request.Quantity);

                existingPart.Quantity += request.Quantity;
                existingPart.Price = request.Price;
            }
            else
            {
                Log.Debug("Creating new warehouse part entry");
                _dbContext.WarehouseParts.Add(new WarehousePart
                {
                    Name = request.PartName,
                    Model = request.Model,
                    Quantity = request.Quantity,
                    Price = request.Price
                });
            }

            await _dbContext.SaveChangesAsync();
            Log.Information("Warehouse parts updated successfully");
            return new Empty();
        }

        public override async Task<Empty> DeletePartFromWarehouse(DeletePartRequest request, ServerCallContext context)
        {
            Log.Information("Deleting part from warehouse. Part: {PartName}, Model: {Model}",
                request.PartName, request.Model);

            var part = await _dbContext.WarehouseParts
                .FirstOrDefaultAsync(p => p.Name == request.PartName && p.Model == request.Model);

            if (part != null)
            {
                _dbContext.WarehouseParts.Remove(part);
                await _dbContext.SaveChangesAsync();
                Log.Information("Part deleted from warehouse");
            }
            else
            {
                Log.Warning("Part not found in warehouse during deletion");
            }

            return new Empty();
        }

        public override async Task<OrderResponse> MarkOrderAsDelivered(OrderRequest request, ServerCallContext context)
        {
            Log.Information("Marking order as delivered. ID: {OrderId}", request.OrderId);

            var order = await _dbContext.Orders
                .Include(o => o.Parts)
                .FirstOrDefaultAsync(o => o.OrderId == request.OrderId);

            if (order != null)
            {
                order.Status = "Выдан";
                await _dbContext.SaveChangesAsync();
                Log.Information("Order marked as delivered successfully. ID: {OrderId}", order.OrderId);
                return MapToOrderResponse(order);
            }

            Log.Error("Order not found when marking as delivered. ID: {OrderId}", request.OrderId);
            throw new RpcException(new Status(StatusCode.NotFound, "Order not found"));
        }



        public override async Task<Empty> UpdateOrderPrice(UpdateOrderPriceRequest request, ServerCallContext context)
        {
            Log.Information("Updating order price. ID: {OrderId}", request.OrderId);

            var order = await _dbContext.Orders
                .Include(o => o.Parts)
                .FirstOrDefaultAsync(o => o.OrderId == request.OrderId);

            if (order == null)
            {
                Log.Error("Order not found during price update. ID: {OrderId}", request.OrderId);
                throw new RpcException(new Status(StatusCode.NotFound, $"Order with ID {request.OrderId} not found"));
            }

            double totalPrice = order.Price;
            Log.Debug("Initial order price: {Price}", totalPrice);

            foreach (var part in order.Parts)
            {
                var warehousePart = await _dbContext.WarehouseParts
                    .FirstOrDefaultAsync(w => w.Name == part.Name && w.Model == part.Model);

                if (warehousePart != null)
                {
                    var partCost = warehousePart.Price * part.Quantity;
                    totalPrice += partCost;
                    Log.Debug("Added part cost: {PartName} x{Quantity} @ {Price} = {Cost}",
                        part.Name, part.Quantity, warehousePart.Price, partCost);
                }
            }

            order.Price = totalPrice;
            await _dbContext.SaveChangesAsync();
            Log.Information("Order price updated successfully. New price: {Price}", totalPrice);

            return new Empty();
        }

        #endregion

        private OrderResponse MapToOrderResponse(Order order)
        {
            var response = new OrderResponse
            {
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                PhoneNumber = order.PhoneNumber,
                DeviceType = order.DeviceType,
                DeviceModel = order.DeviceModel,
                RepairType = order.RepairType,
                Description = order.Description,
                Status = order.Status,
                WarehouseRequestStatus = order.WarehouseRequestStatus,
                OrderDate = order.OrderDate,
                ResponsibleMaster = order.ResponsibleMaster,
                Price = order.Price
            };

            response.Parts.AddRange(order.Parts.Select(p => new Part
            {
                Name = p.Name,
                Quantity = p.Quantity
            }));

            return response;
        }
    }
}
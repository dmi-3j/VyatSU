using Xunit;
using Grpc.Net.Client;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.Net.Http;
using ServiceCenter.Services;
using ServiceCenter.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Sqlite;
using Serilog;
using Serilog.Extensions.Logging;
using Grpc.Core;
using System;
using System.Threading.Tasks;

public class GrpcBasicTest
{
    [Fact]
    public async Task CreateOrder_SimpleGrpcTest()
    {
        // 1. Настраиваем Serilog для записи в файл
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("test-logs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        // 2. SQLite in-memory (с общей базой)
        var connection = new SqliteConnection("Data Source=TestDb;Mode=Memory;Cache=Shared");
        await connection.OpenAsync();

        // 3. Настраиваем TestServer (без UseSerilog)
        var webHostBuilder = new WebHostBuilder()
            .ConfigureServices(services =>
            {
                // Серилог в качестве ILoggerFactory
                services.AddSingleton<ILoggerFactory>(new SerilogLoggerFactory(Log.Logger));

                services.AddLogging(); // обязательно, иначе ILogger<T> не внедрится
                services.AddGrpc();

                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlite(connection));

                services.AddScoped<OrdersServiceImpl>(); // если используется DI
            })
            .Configure(app =>
            {
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapGrpcService<OrdersServiceImpl>();
                });
            });

        using var server = new TestServer(webHostBuilder);

        // 4. Создаем и инициализируем БД
        using (var scope = server.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.EnsureCreatedAsync();
        }

        // 5. Создаем gRPC клиент
        using var channel = GrpcChannel.ForAddress(
            "https://10.8.1.1:9080",
            new GrpcChannelOptions
            {
                HttpClient = server.CreateClient(),
                ThrowOperationCanceledOnCancellation = true
            });

        var client = new OrdersService.OrdersServiceClient(channel);

        var request = new OrderRequest
        {
            CustomerName = "Test Client",
            PhoneNumber = "+1234567890",
            DeviceType = "Смартфон",
            DeviceModel = "Model X",
            RepairType = "Замена экрана",
            Status = "Принят",
            Price = 100.50,
            Parts = { new Part { Name = "Экран", Quantity = 1 } }
        };

        try
        {
            // 6. Отправляем запрос
            var response = await client.CreateOrderAsync(request);

            Assert.NotNull(response);
            Assert.NotEmpty(response.OrderId);

            // 7. Проверяем сохранение в БД
            using var scope = server.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var dbOrder = await db.Orders
                .Include(o => o.Parts)
                .FirstOrDefaultAsync(o => o.OrderId == response.OrderId);

            Assert.NotNull(dbOrder);
            Assert.Equal("Test Client", dbOrder.CustomerName);
            Assert.Single(dbOrder.Parts);
        }
        catch (RpcException ex)
        {
            Log.Error(ex, "gRPC error: {Detail}", ex.Status.Detail);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unexpected error during test");
            throw;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}

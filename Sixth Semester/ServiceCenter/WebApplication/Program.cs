
using System.Security.Cryptography.X509Certificates;
using ServiceCenter.Services;
using DotNetEnv;
using Serilog.Sinks.Elasticsearch;
using Serilog;
var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
Env.Load();
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(Environment.GetEnvironmentVariable("ELASTICSEARCH_URL")))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = "web-application-logs-{0:yyyy.MM.dd}"
                })
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 10)
                .CreateLogger();
builder.Host.UseSerilog();
try
{
    Log.Information("Starting application...");

    builder.Services.AddRazorPages();
    builder.Services.AddControllers();

    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        serverOptions.ListenAnyIP(7283, listenOptions =>
        {
            listenOptions.UseHttps(StoreName.My,
                Environment.GetEnvironmentVariable("HTTPS_CERTIFICATE_HOST"),
                allowInvalid: true);
        });
    });

    builder.Services.AddGrpcClient<OrdersService.OrdersServiceClient>(options =>
    {
        options.Address = new Uri(Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS"));
    });

    var app = builder.Build();

    app.Use(async (context, next) =>
    {
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Incoming HTTP Request: {Method} {Path}",
            context.Request.Method, context.Request.Path);

        try
        {
            await next();
            logger.LogInformation("HTTP Response: {StatusCode}",
                context.Response.StatusCode);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "HTTP Request failed");
            throw;
        }
    });

    app.MapRazorPages();
    app.MapControllers();

    Log.Information("Application started successfully");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

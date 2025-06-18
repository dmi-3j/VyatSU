using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServiceCenter.Services;
using System.Security.Cryptography.X509Certificates;
using ServiceCenter.DB;
using DotNetEnv;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using OpenTelemetry.Logs;
using OpenTelemetry.Instrumentation.GrpcNetClient;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Instrumentation.Http;
using System.Diagnostics;

namespace ServiceCenterServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            Env.Load();
            ConfigureLogging();

            try
            {
                Log.Information("Starting gRPC server");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(Environment.GetEnvironmentVariable("ELASTICSEARCH_URL")!))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = "service-center-logs-{0:yyyy.MM.dd}"
                })
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 10)
                .CreateLogger();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(ConfigureKestrel)
                             .ConfigureServices(ConfigureServices)
                             .Configure(ConfigureApp);
                });

        private static void ConfigureKestrel(KestrelServerOptions options)
        {
            options.ListenAnyIP(9080, listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http2;
                listenOptions.UseHttps(StoreName.My,
                    Environment.GetEnvironmentVariable("HTTPS_CERTIFICATE_HOST") ?? "localhost",
                    allowInvalid: true);
            });
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            ConfigureOpenTelemetry(services);

            services.AddGrpc();
            services.AddDbContext<AppDbContext>();
            services.AddScoped<OrdersServiceImpl>();
            services.AddScoped<MastersServiceImpl>();
        }

        private static void ConfigureOpenTelemetry(IServiceCollection services)
        {
            var resourceBuilder = ResourceBuilder.CreateDefault()
                .AddService(serviceName: "ServiceCenter",
                    serviceVersion: "1.0.0",
                    serviceInstanceId: Environment.MachineName)
                .AddTelemetrySdk()
                .AddEnvironmentVariableDetector();

            services.AddOpenTelemetry()
                .WithTracing(tracerProviderBuilder =>
                {
                    tracerProviderBuilder
                        .SetResourceBuilder(resourceBuilder)
                        .AddSource("ServiceCenter.Orders")
                        .AddSource("ServiceCenter.Masters")
                        .SetSampler(new AlwaysOnSampler())
                        .AddAspNetCoreInstrumentation(options =>
                        {
                            options.RecordException = true;
                            options.EnrichWithHttpRequest = (activity, request) =>
                            {
                                activity.SetTag("http.client_ip", request.HttpContext.Connection.RemoteIpAddress);
                            };
                        })
                        .AddGrpcClientInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddConsoleExporter()
                        .AddJaegerExporter(opt =>
                        {
                            opt.AgentHost = Environment.GetEnvironmentVariable("JAEGER_HOST") ?? "localhost";
                            opt.AgentPort = 6831;
                            opt.ExportProcessorType = OpenTelemetry.ExportProcessorType.Batch;
                        });
                })
                .WithMetrics(metricsProviderBuilder =>
                {
                    metricsProviderBuilder
                        .SetResourceBuilder(resourceBuilder)
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddRuntimeInstrumentation()
                        .AddProcessInstrumentation()
                        .AddConsoleExporter();
                });

            services.AddLogging(logging =>
            {
                logging.AddOpenTelemetry(options =>
                {
                    options.SetResourceBuilder(resourceBuilder)
                           .AddConsoleExporter();
                });
            });
        }

        private static void ConfigureApp(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<OrdersServiceImpl>();
                endpoints.MapGrpcService<MastersServiceImpl>();

                endpoints.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");
            });
        }
    }
}
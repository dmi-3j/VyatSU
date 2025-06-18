using OrderClient;
using System;
using System.Windows.Forms;
using DotNetEnv;
using System.IO;
using Serilog;
using Serilog.Sinks.Elasticsearch;
namespace ServiceCenterWinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.FullName;
            string envPath = Path.Combine(projectRoot, ".env");
            Env.Load(envPath);
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Debug()                     // Минимальный уровень логирования
                 .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(Environment.GetEnvironmentVariable("ELASTICSEARCH_URL")))
                 {
                     AutoRegisterTemplate = true,
                     IndexFormat = "order-client-logs-{0:yyyy.MM.dd}"
                 })
                 .WriteTo.Console()                        // Вывод в консоль
                 .WriteTo.File("logs/log.txt",             // Запись в файл
                 rollingInterval: RollingInterval.Day, // Ротация по дням
                 retainedFileCountLimit: 10)            // Хранить 7 файлов
                .CreateLogger();
            Application.EnableVisualStyles();  
            Application.SetCompatibleTextRenderingDefault(false);
            Log.Information("Started OrderClient Application");
            Application.Run(new OrderForm());
            Log.CloseAndFlush();
        }
    }
}

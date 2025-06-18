using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetEnv;
using Serilog;
using Serilog.Sinks.Elasticsearch;
namespace WarehouseClient
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
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
                     IndexFormat = "warehouse-client-logs-{0:yyyy.MM.dd}"
                 })
                 .WriteTo.Console()                        // Вывод в консоль
                 .WriteTo.File("logs/log.txt",             // Запись в файл
                 rollingInterval: RollingInterval.Day, // Ротация по дням
                 retainedFileCountLimit: 10)            // Хранить 7 файлов
                .CreateLogger();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WarehouseForm());
            Log.CloseAndFlush();
        }
    }
}

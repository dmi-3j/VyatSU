using System;
using System.IO;
using System.Windows.Forms;
using DotNetEnv;
using Serilog;
using Serilog.Sinks.Elasticsearch;
namespace MasterClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.FullName;
            string envPath = Path.Combine(projectRoot, ".env");
            Env.Load(envPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Debug()                     // Минимальный уровень логирования
                 .WriteTo.Console()                        // Вывод в консоль
                 .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(Environment.GetEnvironmentVariable("ELASTICSEARCH_URL")))
                 {
                     AutoRegisterTemplate = true,
                     IndexFormat = "master-client-logs-{0:yyyy.MM.dd}"
                 })
                 .WriteTo.File("logs/log.txt",             // Запись в файл
                 rollingInterval: RollingInterval.Day, // Ротация по дням
                 retainedFileCountLimit: 10)            // Хранить 7 файлов
                .CreateLogger();
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MasterForm(loginForm.AuthenticatedMaster));
                Log.CloseAndFlush();
            }
           
        }
    }
}

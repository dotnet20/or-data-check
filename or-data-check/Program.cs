using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using or_data_check.Interface;
using or_data_check.Services;

namespace or_data_check
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
                ?? throw new Exception("No connection string found.");

            string excelPath = ConfigurationManager.AppSettings["ExcelFilePath"]
                ?? throw new Exception("No path to excel file found.");

            services.AddSingleton<ComparisonService>();
            services.AddSingleton<IExcelService, ExcelService>();
            services.AddSingleton<IDatabaseService>(provider => new DatabaseService(connectionString));
            services.AddTransient(provider => new Form1(
                provider.GetRequiredService<IExcelService>(),
                provider.GetRequiredService<IDatabaseService>(),
                provider.GetRequiredService<ComparisonService>(),
                excelPath
            ));

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }
        }
    }
}
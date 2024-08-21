using FileTestTask.DataBase;
using FileTestTask.Models;
using FileTestTask.Services.Exel;
using FileTestTask.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<App>();
                services.AddSingleton<MainWindow>();
                services.AddTransient<ExcelService>();
                services.AddScoped<IRepository<Record>, RecordRepository>();
                services.AddScoped<IRepository<Account>, AccountRepository>();
                services.AddScoped<IRepository<AccountClass>, AccountClassRepository>();
                services.AddScoped<IRepository<OriginFile>,  OriginFileRepository>();
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });
            })
            .Build();
            var app = host.Services.GetService<App>();
            app?.Run();
        }

    }
}

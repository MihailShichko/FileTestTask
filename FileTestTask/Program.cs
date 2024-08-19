using FileTestTask.DataBase;
using FileTestTask.Models;
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
                services.AddScoped<IRepository<Record>, RecordRepository>();
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer("Data Source=DESKTOP-ARBQ8S0;Database=FileTestTask;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                });
            })
            .Build();
            var app = host.Services.GetService<App>();
            app?.Run();
        }

    }
}

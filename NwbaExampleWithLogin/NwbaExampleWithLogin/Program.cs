using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NwbaExample.Data;
using NwbaExample.Utilities;

namespace NwbaExample
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            IServiceProvider services;
            BillExicuter exicuter;
            var scope = host.Services.CreateScope();


            services = scope.ServiceProvider;
            try
            {
                SeedData.Initialize(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
            exicuter = new BillExicuter(services);

            Task taskA = new Task(() =>
            {
                while (true)
                {
                    Console.WriteLine("exicuteing bills {0}", DateTime.Now);
                    exicuter.ExicuteBill();
                    Thread.Sleep(60000);
                }
            });
            // Start the task.
            taskA.Start();
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}

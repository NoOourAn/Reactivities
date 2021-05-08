using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Linq;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ///to manage to get the services from host
            ///and run the host later after migration
            var host = CreateHostBuilder(args).Build();

            //////////gets an error without these two lines bcz of dependency injection
            ///store any services we r gonna need in Main method inside scope var
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            ///create database if not existP
            try
            {
                var context = services.GetRequiredService<DataContext>();
                context.Database.Migrate();
                Seed.SeedData(context);
            }
            catch (Exception e)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "An error occured during migrations");
            }

            host.Run();
 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

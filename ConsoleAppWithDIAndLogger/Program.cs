using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace ConsoleAppWithDIAndLogger
{
    class Program
    {
        private static IConfiguration Configuration;

        static void Main()
        {
            #region Configuration
            Configuration = new ConfigurationBuilder()
                   .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile("appsettings.serilog.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"}.json", optional: true, reloadOnChange: true)
                   .Build();
            #endregion

            #region Serilog
            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(Configuration)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();
            #endregion

            #region Services
            var host = Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) =>
                    {
                        services.AddTransient<IGreetingService, GreetingService>();
                    })
                    .UseSerilog()
                    .Build(); 
            #endregion

            var greetingSvc = ActivatorUtilities.CreateInstance<GreetingService>(host.Services);
            greetingSvc.Execute();

            Console.ReadLine();
        }
    }
}

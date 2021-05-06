using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace Surzor.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            ConfigureLog();
            var loggerService = host.Services.GetRequiredService<ILogger<Program>>();
            loggerService.LogInformation("Api is Running! ");
            host.Run();
        }
        private static void ConfigureLog()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext().MinimumLevel.Information()
                .WriteTo.Debug()
                .WriteTo.File(
                    $"Logs/Log-{DateTime.Now.ToShortDateString().Replace("/", "")}.log")
                .WriteTo.Console()
                .CreateLogger();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

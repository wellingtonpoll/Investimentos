using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Diagnostics;

namespace Investimentos.Servico.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var hostBuilder = CreateHostBuilder(args).Build();
                Log.Information("Aplicação inicializada com sucesso!");
                hostBuilder.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Aplicação finalizou de forma inesperada!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {

                    var configuration = config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true)
                        .Build();

                    var connectionString = configuration.GetConnectionString("investimentosdb");

                    Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.MongoDB(databaseUrl: connectionString, collectionName: "logs")
                        .CreateLogger();
                })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

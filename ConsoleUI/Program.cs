
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

//DI, Logging: Serilog, Settings

namespace ConsoleUI
{
    class Program
    {
        public abstract record Person(string FirstName, string LastName);
        public record Teacher(string FirstName, string LastName, int Grade);
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ISnippetService, SnippetService>(); //give me new instance every time I need it
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<SnippetService>(host.Services);
            svc.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            //configuration source
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production" }.json", optional: true)
                .AddEnvironmentVariables(); //if we want to override
        }
    }
}

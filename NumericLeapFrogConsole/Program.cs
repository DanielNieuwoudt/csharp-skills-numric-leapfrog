﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NumericLeapFrogConsole;
using NumericLeapFrogConsole.Extensions;

namespace NumericLeapfrog
{
    [ExcludeFromCodeCoverage(Justification = "Wiring")]
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true, true);
                    config.AddEnvironmentVariables();

                })
                .ConfigureServices(services =>
                {
                    services.AddApplication();
                })
                .Build();

            var application = host
                .Services
                .GetRequiredService<IApplication>();

            await application.RunAsync(isRunOnce: false, isGameMode: true);
        }
    }
}

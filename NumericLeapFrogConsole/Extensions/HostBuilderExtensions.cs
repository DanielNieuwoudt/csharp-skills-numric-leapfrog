using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace NumericLeapFrogConsole.Extensions
{
    [ExcludeFromCodeCoverage(Justification = "Wiring")]
    internal static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureSerilog(this IHostBuilder builder)
        {
            builder.UseSerilog((host, services, loggerConfig) =>
            {
                loggerConfig
                    .ReadFrom.Configuration(host.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext();
            });

            return builder;
        }
    }
}

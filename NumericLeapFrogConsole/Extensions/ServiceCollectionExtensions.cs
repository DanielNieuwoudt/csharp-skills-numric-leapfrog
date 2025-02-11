using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using NumericLeapFrogConsole.Helpers;

namespace NumericLeapFrogConsole.Extensions
{
    [ExcludeFromCodeCoverage(Justification = "Wiring")]
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IConsoleHelper, ConsoleHelper>();
            services.AddTransient<IPlayerInputHelper, PlayerInputHelper>();
            
            services.AddTransient<IApplication, Application>();

            return services;
        }
    }
}

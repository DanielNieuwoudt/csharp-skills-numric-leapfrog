using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace NumericLeapFrogConsole.Extensions
{
    [ExcludeFromCodeCoverage(Justification = "Wiring")]
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IApplication, Application>();

            return services;
        }
    }
}

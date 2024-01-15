using Helper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Prescription.Models.Configuration {
    /// <summary>
    /// Extension methods for configuring models-related services in the Prescription application.
    /// </summary>
    public static class ServiceCollectionExtensions {
        /// <summary>
        /// Adds models-related configuration services to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddModelsConfiguration(this IServiceCollection services) {
            // Register services from the executing assembly using reflection.
            services.RegisterAssemblyServices(Assembly.GetExecutingAssembly());

            // Return the configured IServiceCollection for further chaining.
            return services;
        }
    }
}

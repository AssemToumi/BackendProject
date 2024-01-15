using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Helper;
using Prescription.Business.Configuration;

namespace Prescription.Facades.Configuration {
    /// <summary>
    /// Extension methods for configuring facades-related services in the Prescription application.
    /// </summary>
    public static class ServiceCollectionExtensions {
        /// <summary>
        /// Adds facades-related configuration services to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddFacadesConfiguration(this IServiceCollection services, IConfiguration configuration) {
            // Retrieve the executing assembly to use for configuration.
            var executingAssembly = Assembly.GetExecutingAssembly();

            // Add AutoMapper services with mappings defined in the executing assembly.
            services.AddAutoMapper(executingAssembly);

            // Add services configuration based on the provided configuration.
            services.AddServicesConfiguration(configuration);

            // Register services from the executing assembly using reflection.
            services.RegisterAssemblyServices(executingAssembly);

            // Return the configured IServiceCollection for further chaining.
            return services;
        }
    }
}

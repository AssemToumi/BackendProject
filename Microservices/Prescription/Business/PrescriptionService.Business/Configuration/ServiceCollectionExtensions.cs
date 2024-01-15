using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Helper;
using Prescription.DataAccess.Configuration;

namespace Prescription.Business.Configuration {
    /// <summary>
    /// Extension methods for configuring business-related services in the Prescription application.
    /// </summary>
    public static class ServiceCollectionExtensions {
        /// <summary>
        /// Adds business-related configuration services to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration) {
            // Add data access configuration services based on the provided configuration.
            services.AddDataAccessConfiguration(configuration);

            // Register services from the executing assembly using reflection.
            services.RegisterAssemblyServices(Assembly.GetExecutingAssembly());

            // Return the configured IServiceCollection for further chaining.
            return services;
        }
    }
}

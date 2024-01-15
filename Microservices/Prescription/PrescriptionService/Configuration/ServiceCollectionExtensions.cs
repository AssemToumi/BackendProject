using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using Helper;
using Prescription.Facades.Configuration;

namespace PrescriptionService.Configuration {
    /// <summary>
    /// Extension methods for configuring services in the PrescriptionService application.
    /// </summary>
    public static class ServiceCollectionExtensions {
        /// <summary>
        /// Adds configuration-related services to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration) {
            // Configure Serilog logging with the provided configuration.
            services.AddSerilog(configuration)
                    // Add facades configuration based on the provided configuration.
                    .AddFacadesConfiguration(configuration);

            // Add API Explorer services for endpoint information.
            services.AddEndpointsApiExplorer();

            // Add Swagger services for API documentation.
            services.AddSwaggerGen();

            // Add controllers with specific JSON serialization options.
            services.AddControllers()
                    // Configure JSON serialization options with StringEnumConverter.
                    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
                    // Configure JSON serialization options to ignore reference cycles.
                    .AddJsonOptions(opts => opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Add a singleton instance of the LDAP authentication service with a specific domain.
            services.AddSingleton<IAuthenticationService>(new LdapAuthenticationService("Prescription.local", null));

            // Return the configured IServiceCollection for further chaining.
            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Helper;
using Prescription.DataAccess.Contexts;
using Prescription.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Prescription.DataAccess.Configuration {
    /// <summary>
    /// Extension methods for configuring data access services in the Prescription application.
    /// </summary>
    public static class ServiceCollectionExtensions {
        /// <summary>
        /// Adds data access configuration to the service collection.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        /// <param name="configuration">The configuration containing database settings.</param>
        /// <returns>The configured service collection.</returns>
        public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services, IConfiguration configuration) {
            // Add configurations for models
            services.AddModelsConfiguration();

            // Register data access options from configuration
            services.RegisterDataAccessOptions(configuration);

            // Register services from the executing assembly
            services.RegisterAssemblyServices(Assembly.GetExecutingAssembly());

            // Get the selected database provider from the configuration
            var provider = configuration.GetSection("DatabaseSettings").GetValue<Providers>("Provider");

            // Configure DbContext based on the selected provider
            ConfigureDbContext(services, provider);

            // Ensure database migration
            EnsureDatabaseMigration(services);

            return services;
        }

        /// <summary>
        /// Configures the DbContext based on the selected provider from the configuration.
        /// </summary>
        private static void ConfigureDbContext(IServiceCollection services, Providers provider) {
            switch (provider) {
                case Providers.Oracle:
                    services.AddDbContext<PrescriptionDbContext, PrescriptionOracleDbContext>();
                    break;
                case Providers.MsSqlServer:
                    services.AddDbContext<PrescriptionDbContext, PrescriptionSqlServerDbContext>();
                    break;
                case Providers.InMemory:
                    services.AddDbContext<PrescriptionDbContext, PrescriptionInMemoryDbContext>();
                    break;
                default:
                    throw new NotImplementedException($"Provider <{provider}> is not supported!");
            }
        }

        /// <summary>
        /// Ensures database migration by applying pending migrations.
        /// </summary>
        private static void EnsureDatabaseMigration(IServiceCollection services) {
            using (var scope = services.BuildServiceProvider().CreateScope()) {
                var dbContext = scope.ServiceProvider.GetRequiredService<PrescriptionDbContext>();
                dbContext.Database.Migrate();

                ApplyLatestMigration(dbContext);
            }
        }

        private static void ApplyLatestMigration(PrescriptionDbContext dbContext) {
            // Check if there are any pending migrations
            var pendingMigrations = dbContext.Database.GetPendingMigrations();

            if (pendingMigrations.Any()) {
                // Apply the latest migration if there are pending migrations
                dbContext.Database.Migrate();
            }
        }

        /// <summary>
        /// Registers data access options from the configuration.
        /// </summary>
        private static IServiceCollection RegisterDataAccessOptions(this IServiceCollection services, IConfiguration configuration) {
            services.Configure<SqlSettings>(opts =>
                configuration.GetSection("DatabaseSettings:MsSqlServer").Bind(opts));

            // Add other configurations as needed for different providers

            return services;
        }
    }
}

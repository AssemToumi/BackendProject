using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Helper;
using Prescription.Models.Abstractions;

namespace Prescription.DataAccess.Contexts {
    /// <summary>
    /// Represents the DbContext for interacting with SQL Server database in the Prescription application.
    /// </summary>
    public partial class PrescriptionSqlServerDbContext : PrescriptionDbContext {
        // Constructor for PrescriptionSqlServerDbContext.
        public PrescriptionSqlServerDbContext(DbContextOptions options, IConfiguration configuration, IConnectedUser connectedUser)
            : base(options, configuration, connectedUser) {
        }

        // Configures the DbContext options, including the connection string for SQL Server.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);

            // Use the connection string named "Prescription" from the application configuration.
            optionsBuilder.UseMsSqlServerProvider(Configuration.GetConnectionString("Prescription")!);
        }
    }
}

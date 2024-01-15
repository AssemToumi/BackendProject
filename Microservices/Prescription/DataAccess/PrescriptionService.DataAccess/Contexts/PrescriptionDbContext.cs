using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Prescription.Models.Abstractions;
using Prescription.Models.Entities;

namespace Prescription.DataAccess.Contexts {
    /// <summary>
    /// Base class for DbContext in the Prescription application, providing common functionality.
    /// </summary>
    public abstract class PrescriptionDbContext : DbContext {
        private readonly IConnectedUser _connectedUser;

        // Configuration for the DbContext.
        protected readonly IConfiguration Configuration;

        // Constructor for initializing the DbContext with configuration and connected user information.
        protected PrescriptionDbContext(IConfiguration configuration, IConnectedUser connectedUser) {
            _connectedUser = connectedUser;
            Configuration = configuration;
        }

        // Constructor for initializing the DbContext with options, configuration, and connected user information.
        protected PrescriptionDbContext(DbContextOptions options, IConfiguration configuration, IConnectedUser connectedUser)
            : base(options) {
            _connectedUser = connectedUser;
            Configuration = configuration;
        }

        // Constructor for initializing the DbContext with generic options, configuration, and connected user information.
        protected PrescriptionDbContext(DbContextOptions<PrescriptionDbContext> options, IConfiguration configuration, IConnectedUser connectedUser)
            : base(options) {
            _connectedUser = connectedUser;
            Configuration = configuration;
        }

        // Configures additional options for the DbContext.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);

            // Enable lazy loading proxies for navigation properties.
            optionsBuilder.UseLazyLoadingProxies();
        }

        // Configures the model for the DbContext.
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Configure the 'Patients' entity with table name and primary key.
            modelBuilder.Entity<PatientEntity>(entity => {
                entity.ToTable("MS_Patient");
                entity.HasKey(k => k.Id);
            });
        }

        // Overrides SaveChangesAsync to handle common logic before saving changes to the database.
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new()) {
            // Get a list of entries for entities derived from AbstractPrescriptionBaseEntity.
            List<EntityEntry<AbstractPrescriptionBaseEntity>> entries = ChangeTracker.Entries<AbstractPrescriptionBaseEntity>().ToList();

            // Iterate through each entry and update CreatorId, CreationDate, RowVersion, ModificatorId, and ModificationDate.
            entries.ForEach(e => {
                if (e.State == EntityState.Added) {
                    e.Entity.CreatorId = _connectedUser.Id;
                    e.Entity.CreationDate = DateTime.UtcNow;
                    e.Entity.RowVersion = 1;
                }
                else if (e.State == EntityState.Modified) {
                    e.Property(p => p.CreatorId).IsModified = false;
                    e.Property(p => p.CreationDate).IsModified = false;
                    e.Property(p => p.RowVersion).CurrentValue++;
                }

                e.Entity.ModificatorId = _connectedUser.Id;
                e.Entity.ModificationDate = DateTime.UtcNow;
            });

            // Save changes to the database and return the result.
            return await base.SaveChangesAsync(cancellationToken);
        }

        #region DbSets

        // DbSet for the 'Patients' entity.
        public DbSet<PatientEntity> Patients { get; set; } = null!;

        #endregion
    }
}

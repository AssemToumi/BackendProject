using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using PrescriptionService.Models.PrescriptionService.Model.Abstractions;
using PrescriptionService.Models.PrescriptionService.Model.Entities;

namespace PrescriptionService.DataAccess.PrescriptionService.DataAccess.Contexts;

public abstract class PrescriptionDbContext : DbContext
{
    private readonly IConnectedUser _connectedUser;

    protected readonly IConfiguration Configuration;

    protected PrescriptionDbContext(IConfiguration configuration, IConnectedUser connectedUser)
    {
        _connectedUser = connectedUser;
        Configuration = configuration;
    }

    protected PrescriptionDbContext(DbContextOptions options, IConfiguration configuration, IConnectedUser connectedUser)
        : base(options)
    {
        _connectedUser = connectedUser;
        Configuration = configuration;
    }

    protected PrescriptionDbContext(DbContextOptions<PrescriptionDbContext> options, IConfiguration configuration, IConnectedUser connectedUser)
        : base(options)
    {
        _connectedUser = connectedUser;
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        List<EntityEntry<AbstractPrescriptionBaseEntity>> entries = ChangeTracker.Entries<AbstractPrescriptionBaseEntity>().ToList();

        entries.ForEach(e =>
        {
            if (e.State == EntityState.Added)
            {
                e.Entity.CreatorId = _connectedUser.Id;
                e.Entity.CreatorId = 1;
                e.Entity.CreationDate = DateTime.UtcNow;
                e.Entity.RowVersion = 1;
            }
            else if (e.State == EntityState.Modified)
            {
                e.Property(p => p.CreatorId).IsModified = false;
                e.Property(p => p.CreationDate).IsModified = false;
                e.Property(p => p.RowVersion).CurrentValue++;
            }

            e.Entity.ModificatorId = _connectedUser.Id;
            e.Entity.ModificatorId = 1;
            e.Entity.ModificationDate = DateTime.Now;
        });

        return await base.SaveChangesAsync(cancellationToken);
    }

    #region DbSets
    public DbSet<PatientEntity> Patients { get; set; } = null!;

    #endregion
}
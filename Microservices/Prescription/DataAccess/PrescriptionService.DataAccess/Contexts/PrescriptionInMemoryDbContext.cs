using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prescription.Models.Abstractions;

namespace Prescription.DataAccess.Contexts;

public class PrescriptionInMemoryDbContext : PrescriptionDbContext {
    public PrescriptionInMemoryDbContext(DbContextOptions options, IConfiguration configuration, IConnectedUser connectedUser)
        : base(options, configuration, connectedUser) {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseInMemoryDatabase("Prescription");
    }
}
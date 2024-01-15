
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Helper;
using PrescriptionService.Models.PrescriptionService.Model.Abstractions;

namespace PrescriptionService.DataAccess.PrescriptionService.DataAccess.Contexts;

public partial class PrescriptionSqlServerDbContext : PrescriptionDbContext
{
    public PrescriptionSqlServerDbContext(DbContextOptions options, IConfiguration configuration, IConnectedUser connectedUser)
        : base(options, configuration, connectedUser)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseMsSqlServerProvider(Configuration.GetConnectionString("Prescription")!);
    }
}
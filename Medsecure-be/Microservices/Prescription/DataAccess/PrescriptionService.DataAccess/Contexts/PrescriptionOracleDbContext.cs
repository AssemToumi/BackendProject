using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Helper;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Configuration;
using PrescriptionService.Models.PrescriptionService.Model.Abstractions;

namespace PrescriptionService.DataAccess.PrescriptionService.DataAccess.Contexts;

public class PrescriptionOracleDbContext : PrescriptionDbContext
{
    private readonly OracleSettings _oracleOptions;

    public PrescriptionOracleDbContext(DbContextOptions options, IConfiguration configuration, IOptions<OracleSettings> oracleOptions, IConnectedUser connectedUser)
        : base(options, configuration, connectedUser)
        => _oracleOptions = oracleOptions.Value;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseOracleProvider(Configuration.GetConnectionString("Prescription")!,
            _oracleOptions.SqlCompatibilityVersion);
    }
}
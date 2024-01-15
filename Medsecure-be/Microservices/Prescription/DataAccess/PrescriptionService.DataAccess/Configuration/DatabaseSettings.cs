using Helper;

namespace PrescriptionService.DataAccess.PrescriptionService.DataAccess.Configuration;

public class DatabaseSettings
{
    public Providers Provider { get; set; }

    public OracleSettings? OracleOptions { get; set; }
}

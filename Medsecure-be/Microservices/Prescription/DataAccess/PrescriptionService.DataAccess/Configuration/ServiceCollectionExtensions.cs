using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Helper;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Contexts;
using PrescriptionService.Models.PrescriptionService.Model.Configuration;

namespace PrescriptionService.DataAccess.PrescriptionService.DataAccess.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddModelsConfiguration();
        services.RegisterDataAccessOptions(configuration);
        services.RegisterAssemblyServices(Assembly.GetExecutingAssembly());

        var provider = configuration.GetSection("DatabaseSettings").GetValue<Providers>("Provider");

        switch (provider)
        {
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

        return services;
    }

    private static IServiceCollection RegisterDataAccessOptions(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<OracleSettings>(opts =>
            configuration.GetSection("DatabaseSettings:OracleSettings").Bind(opts));

        return services;
    }
}


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Helper;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Configuration;

namespace PrescriptionService.Business.PrescriptionService.Business.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDataAccessConfiguration(configuration);
        services.RegisterAssemblyServices(Assembly.GetExecutingAssembly());

        return services;
    }

}
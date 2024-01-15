using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Helper;
using PrescriptionService.Business.PrescriptionService.Business.Configuration;

namespace PrescriptionService.Business.PrescriptionService.Facades.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFacadesConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(executingAssembly);
        services.AddServicesConfiguration(configuration);
        services.RegisterAssemblyServices(executingAssembly);

        return services;
    }
}
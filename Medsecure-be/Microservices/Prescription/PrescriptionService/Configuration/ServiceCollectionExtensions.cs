using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using PrescriptionService.Business.PrescriptionService.Facades.Configuration;
using Helper;

namespace PrescriptionService.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog(configuration)
            .AddFacadesConfiguration(configuration);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
            .AddJsonOptions(opts => opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddSingleton<IAuthenticationService>(new LdapAuthenticationService("Prescription.local", null));

        return services;
    }
}


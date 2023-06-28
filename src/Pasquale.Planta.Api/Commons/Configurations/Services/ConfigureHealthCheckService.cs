using Pasquale.Planta.Api.Persistences.Contexts;

namespace Pasquale.Planta.Api.Commons.Configurations.Services;

public static class ConfigureHealthCheckService
{
    public static void AddHealthCheckService(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddDbContextCheck<DefaultContext>();
    }
}
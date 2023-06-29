using Pasquale.Plant.Api.Persistences.Contexts;

namespace Pasquale.Plant.Api.Commons.Configurations.Services;

public static class ConfigureHealthCheckService
{
    public static void AddHealthCheckService(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddDbContextCheck<DefaultContext>();
    }
}
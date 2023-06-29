using Haruki.Api.Persistences.Contexts;

namespace Haruki.Api.Commons.Configurations.Services;

public static class ConfigureHealthCheckService
{
    public static void AddHealthCheckService(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddDbContextCheck<DefaultContext>();
    }
}
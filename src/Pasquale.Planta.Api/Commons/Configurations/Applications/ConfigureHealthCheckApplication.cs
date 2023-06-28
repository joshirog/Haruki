using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Pasquale.Planta.Api.Commons.Configurations.Applications;

public static class ConfigureHealthCheckApplication
{
    public static void AddHealthCheckApplication(this WebApplication app)
    {
        app.MapHealthChecks("/", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }
}
using Microsoft.EntityFrameworkCore;
using Pasquale.Planta.Api.Persistences.Contexts;

namespace Pasquale.Planta.Api.Commons.Configurations.Services;

public static class ConfigureContextService
{
    public static void AddContextService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =  string. Empty;

        services.AddDbContext<DefaultContext>(options =>
            options.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly(typeof(DefaultContext).Assembly.FullName)));
    }
}
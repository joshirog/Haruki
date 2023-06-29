using Microsoft.EntityFrameworkCore;
using Pasquale.Plant.Api.Persistences.Contexts;

namespace Pasquale.Plant.Api.Commons.Configurations.Services;

public static class ConfigureContextService
{
    public static void AddContextService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DefaultContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(DefaultContext).Assembly.FullName)));
    }
}
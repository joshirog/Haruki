using Haruki.Api.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Haruki.Api.Commons.Configurations.Services;

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
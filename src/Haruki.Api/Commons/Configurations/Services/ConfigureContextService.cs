using Haruki.Api.Commons.Constants;
using Haruki.Api.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Haruki.Api.Commons.Configurations.Services;

public static class ConfigureContextService
{
    public static void AddContextService(this IServiceCollection services)
    {
        services.AddDbContext<DefaultContext>(options =>
            options.UseNpgsql(SettingConstant.DefaultConnectionString, b => b.MigrationsAssembly(typeof(DefaultContext).Assembly.FullName)));
    }
}
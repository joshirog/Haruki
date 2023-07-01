using Haruki.Api.Commons.Constants;

namespace Haruki.Api.Commons.Configurations.Services;

public static class ConfigureCorsService
{
    public static void AddCorsService(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(SettingConstant.Cors,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
    }
}
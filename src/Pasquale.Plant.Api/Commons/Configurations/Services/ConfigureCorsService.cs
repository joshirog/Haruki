namespace Pasquale.Plant.Api.Commons.Configurations.Services;

public static class ConfigureCorsService
{
    public static void AddCorsService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(configuration.GetSection("AppSettings:Cors").ToString()!,
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
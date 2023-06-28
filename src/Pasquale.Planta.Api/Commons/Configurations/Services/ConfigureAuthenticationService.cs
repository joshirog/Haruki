namespace Pasquale.Planta.Api.Commons.Configurations.Services;

public static class ConfigureAuthenticationService
{
    public static void AddAuthenticationService(this IServiceCollection services)
    {
        /*
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = config.Get("SecurityServiceEndPoint");
                options.RequireHttpsMetadata = true;
                //options.Audience = config.Get("ProcessName");
                options.Audience = "Invoice";
            });
            */
    }
}
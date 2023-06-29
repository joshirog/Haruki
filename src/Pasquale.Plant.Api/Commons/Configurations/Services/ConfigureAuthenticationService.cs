namespace Pasquale.Plant.Api.Commons.Configurations.Services;

public static class ConfigureAuthenticationService
{
    public static void AddAuthenticationService(this IServiceCollection services)
    {
        services.AddAuthentication();
    }
}
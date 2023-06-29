using Hangfire;
using HangfireBasicAuthenticationFilter;

namespace Pasquale.Plant.Api.Commons.Configurations.Applications;

public static class ConfigureHangfireApplication
{
    public static void AddHangfireApplication(this WebApplication app, IConfiguration configuration)
    {
        app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            DashboardTitle = "Hangfire Dashboard",
            Authorization = new[]
            {
                new HangfireCustomBasicAuthenticationFilter
                {
                    User = configuration.GetSection("Hangfire:Credentials:UserName").Value,
                    Pass = configuration.GetSection("Hangfire:Credentials:Password").Value
                }
            }
        });
    }
}
using Hangfire;
using HangfireBasicAuthenticationFilter;
using Haruki.Api.Commons.Constants;

namespace Haruki.Api.Commons.Configurations.Applications;

public static class ConfigureHangfireApplication
{
    public static void AddHangfireApplication(this WebApplication app)
    {
        app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            DashboardTitle = "Hangfire Dashboard",
            Authorization = new[]
            {
                new HangfireCustomBasicAuthenticationFilter
                {
                    User = SettingConstant.HangfireUserName,
                    Pass = SettingConstant.HangfirePassword,
                }
            }
        });
    }
}
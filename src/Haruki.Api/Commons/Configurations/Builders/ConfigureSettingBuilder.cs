using Haruki.Api.Commons.Constants;

namespace Haruki.Api.Commons.Configurations.Builders;

public static class ConfigureSettingBuilder
{
    public static void AddSettingBuilder(this WebApplicationBuilder builder)
    {
        builder.Host.ConfigureAppConfiguration((_, configuration) =>
        {
            SettingConstant.LoadSetting(configuration.Build());
        });

        builder.Configuration.Sources.Clear();
    }
}
using Hangfire;
using Hangfire.PostgreSql;
using Haruki.Api.Commons.Constants;

namespace Haruki.Api.Commons.Configurations.Services;

public static class ConfigureHangfireService
{
    public static void AddHangfireService(this IServiceCollection services)
    {
        services.AddHangfire(hangfire =>
        {
            hangfire.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
            hangfire.UseSimpleAssemblyNameTypeSerializer();
            hangfire.UseRecommendedSerializerSettings();
            hangfire.UseColouredConsoleLogProvider();
            hangfire.UsePostgreSqlStorage(SettingConstant.HangfireConnectionString, 
                new PostgreSqlStorageOptions
                {
                    SchemaName = "hangfire",
                    AllowUnsafeValues = true,
                    QueuePollInterval = TimeSpan.FromSeconds(30),
                    UseNativeDatabaseTransactions = true,
                    PrepareSchemaIfNecessary = true,
                    TransactionSynchronisationTimeout = TimeSpan.FromMinutes(15)
                });
        });

        services.AddHangfireServer();
    }
}
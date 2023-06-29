using Hangfire;
using Hangfire.PostgreSql;

namespace Pasquale.Plant.Api.Commons.Configurations.Services;

public static class ConfigureHangfireService
{
    public static void AddHangfireService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(hangfire =>
        {
            hangfire.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
            hangfire.UseSimpleAssemblyNameTypeSerializer();
            hangfire.UseRecommendedSerializerSettings();
            hangfire.UseColouredConsoleLogProvider();
            hangfire.UsePostgreSqlStorage(configuration.GetConnectionString("HangfireConnection"), 
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
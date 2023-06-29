using Haruki.Api.Tasks;

namespace Haruki.Api.Commons.Configurations.Services;

public static class ConfigureTaskService
{
    public static void AddTaskService(this IServiceCollection services)
    {
        services.AddHostedService<SeederTask>();
    }
}
using Pasquale.Plant.Api.Tasks;

namespace Pasquale.Plant.Api.Commons.Configurations.Services;

public static class ConfigureTaskService
{
    public static void AddTaskService(this IServiceCollection services)
    {
        services.AddHostedService<SeederTask>();
    }
}
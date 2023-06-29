using Pasquale.Plant.Api.Persistences.Seeders;

namespace Pasquale.Plant.Api.Tasks;

public class SeederTask : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public SeederTask(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        IdentitySeeder.Seed(_serviceProvider);
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
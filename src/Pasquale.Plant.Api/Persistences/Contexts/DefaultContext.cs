using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pasquale.Plant.Api.Commons.Bases;
using Pasquale.Plant.Api.Commons.Interfaces;
using Pasquale.Plant.Api.Domains.Entities;

namespace Pasquale.Plant.Api.Persistences.Contexts;


public class DefaultContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeService _dateTimeService;
    private readonly IDomainEventService _domainEventService;
    private readonly ILoggerFactory _loggerFactory;

    public DefaultContext(DbContextOptions options, ICurrentUserService currentUserService, IDateTimeService dateTimeService, IDomainEventService domainEventService, ILoggerFactory loggerFactory) : base(options)
    {
        _currentUserService = currentUserService;
        _dateTimeService = dateTimeService;
        _domainEventService = domainEventService;
        _loggerFactory = loggerFactory;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.CreatedAt = _dateTimeService.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = _currentUserService.UserId;
                    entry.Entity.UpdatedAt = _dateTimeService.Now;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
            }
        }

        var events = ChangeTracker.Entries<IHasDomainEvent>()
            .Select(x => x.Entity.DomainEvents)
            .SelectMany(x => x)
            .Where(domainEvent => !domainEvent.IsPublished)
            .ToArray();

        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents(events);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
            
        builder.HasPostgresExtension("uuid-ossp");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseLoggerFactory(_loggerFactory);
    }
    
    private async Task DispatchEvents(DomainEvent[] events)
    {
        foreach (var @event in events)
        {
            @event.IsPublished = true;
            await _domainEventService.Publish(@event);
        }
    }
}
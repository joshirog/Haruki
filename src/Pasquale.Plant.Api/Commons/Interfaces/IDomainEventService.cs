namespace Pasquale.Plant.Api.Commons.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
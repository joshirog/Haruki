namespace Haruki.Api.Commons.Interfaces;

public interface IHasDomainEvent
{
    public List<DomainEvent> DomainEvents { get; }
}

public abstract class DomainEvent
{
    protected DomainEvent()
    {
        DateOccurred = DateTimeOffset.UtcNow;
    }
    
    public bool IsPublished { get; set; }
    
    public DateTimeOffset DateOccurred { get; protected set; }
}

namespace TripAhead.Common;

public abstract class Entity
{
    public Guid Id { get; init; }

    protected readonly List<IDomainEvent> _domainEvents = [];

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
    
    public List<IDomainEvent> TakeEvents()
    {
        var events = _domainEvents.ToList();
        _domainEvents.Clear();

        return events;
    }
}
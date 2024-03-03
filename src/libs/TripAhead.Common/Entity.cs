namespace TripAhead.Common;

public abstract class Entity
{
    public Guid Id { get; init; }

    protected readonly List<IDomainEvent> _domainEvents = [];

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}
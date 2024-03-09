using TripAhead.Common;

namespace TripAhead.Trips.Domain.Events;

public record TripPublished(Guid TripId) : IDomainEvent
{
}
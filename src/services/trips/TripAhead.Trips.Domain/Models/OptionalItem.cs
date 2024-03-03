using TripAhead.Trips.Domain.Enums;

namespace TripAhead.Trips.Domain.Models;

public class OptionalItem
{
    public OptionalItemType Type { get; init; }
    public Guid TripId { get; init; }
}
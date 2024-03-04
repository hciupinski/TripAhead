using TripAhead.Common;
using TripAhead.Trips.Domain.Enums;

namespace TripAhead.Trips.Domain.Models;

public class OptionalItem : Entity
{
    public OptionalItemType Type { get; init; }
    public Guid TripId { get; init; }
    public virtual Trip Trip { get; init; }
    
    private OptionalItem() {}

    public OptionalItem(Trip trip, OptionalItemType type)
    {
        Trip = trip;
        TripId = TripId;
        Type = type;
    }
}
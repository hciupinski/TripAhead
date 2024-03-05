using TripAhead.Common;
using TripAhead.Trips.Domain.Enums;

namespace TripAhead.Trips.Domain.Models;

public sealed class TripOptionalItem : Entity
{
    public Guid OptionalItemId { get; init; }
    public OptionalItem OptionalItem { get; init; }
    public Guid TripId { get; init; }
    public Trip Trip { get; init; }

    public decimal Price { get; private set; }
    
    public TripOptionalItem(Trip trip, OptionalItem optionalItem)
    {
        Trip = trip;
        TripId = trip.Id;
        OptionalItem = optionalItem;
        OptionalItemId = optionalItem.Id;

        Price = optionalItem.DefaultPrice;
    }

    public TripOptionalItem SetPrice(decimal price)
    {
        Price = price;
        return this;
    }
    
    private TripOptionalItem() {}
}
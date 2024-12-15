using TripAhead.Libs.Common.Base;

namespace TripAhead.Services.Trips.Domain.Entities;

public sealed class TripOptionalItem : BaseEntity
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
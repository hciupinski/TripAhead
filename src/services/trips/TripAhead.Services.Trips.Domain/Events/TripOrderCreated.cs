using TripAhead.Libs.Common.Base;

namespace TripAhead.Services.Trips.Domain.Events;

public class TripOrderCreated(Guid orderId, Guid tripId) : BaseEvent
{
    public Guid OrderId { get; } = orderId;
    public Guid TripId { get; } = tripId;
}
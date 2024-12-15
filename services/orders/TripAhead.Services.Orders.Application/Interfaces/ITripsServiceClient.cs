namespace TripAhead.Services.Orders.Application.Interfaces;

public interface ITripsServiceClient
{
    Task<bool> NotifyNewOrderAsync(Guid orderId, Guid tripId);
}
using TripAhead.Services.Orders.Application.Interfaces;
using TripsService;

namespace TripAhead.Services.Orders.Infrastructure.Services;

public class TripsServiceClient : ITripsServiceClient
{
    private readonly Trips.TripsClient _client;

    public TripsServiceClient(Trips.TripsClient client)
    {
        _client = client;
    }

    public async Task<bool> NotifyNewOrderAsync(Guid orderId, Guid tripId)
    {
        var request = new NewOrderRequest
        {
            OrderId = orderId.ToString(),
            TripId = tripId.ToString()
        };

        var response = await _client.NotifyNewOrderAsync(request);
        return response.Success;
    }
}
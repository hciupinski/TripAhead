using Grpc.Core;
using MediatR;
using TripAhead.Services.Trips.Domain.Events;
using TripsService;

namespace TripAhead.Services.Trips.API.Services;

public class TripsService : global::TripsService.Trips.TripsBase
{
    private readonly IMediator _mediator;
    
    public TripsService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<NotificationResponse> NotifyNewOrder(NewOrderRequest request, ServerCallContext context)
    {
        Console.WriteLine($"Received new order notification: OrderId={request.OrderId}, TripId={request.TripId}");

        // Business logic to mark the new client on the trip
        Guid orderId = Guid.Parse(request.OrderId);
        Guid tripId = Guid.Parse(request.TripId);
        await _mediator.Publish(new TripOrderCreated(orderId, tripId));
        
        bool success = true;
        
        return new NotificationResponse
        {
            Success = success,
            Message = success ? "Trip updated successfully" : "Failed to update trip"
        };
    }
}
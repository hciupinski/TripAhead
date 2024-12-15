using MediatR;
using TripAhead.Services.Orders.Domain.Events;

namespace TripAhead.Services.Orders.Application.Features.Orders.Commands.EventHandlers;

public class OrderCreatedEventHandler : INotificationHandler<OrderCreated>
{
    public Task Handle(OrderCreated notification, CancellationToken cancellationToken)
    {
        // ITripServiceClient.OrderCreated
        throw new NotImplementedException();
    }
}
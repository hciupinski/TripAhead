using MediatR;

namespace TripAhead.Services.Orders.Application.Features.Orders.Commands.CancelOrder;

public class CancelOrder
{
    public record Command(Guid Id) : IRequest;
}
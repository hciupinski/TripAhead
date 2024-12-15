using MediatR;
using TripAhead.Services.Orders.Domain.Entities;

namespace TripAhead.Services.Orders.Application.Features.Orders.Queries.GetOrders;

public class GetOrders
{
    public record Query() : IRequest<Order[]>;
}
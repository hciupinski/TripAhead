using MediatR;
using TripAhead.Services.Orders.Domain.Entities;

namespace TripAhead.Services.Orders.Application.Features.Orders.Queries.GetOrder;

public class GetOrder
{
    public record Query(Guid Id) : IRequest<Order>;
}
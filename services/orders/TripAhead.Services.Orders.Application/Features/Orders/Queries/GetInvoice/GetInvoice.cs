using MediatR;
using TripAhead.Services.Orders.Domain.Entities;

namespace TripAhead.Services.Orders.Application.Features.Orders.Queries.GetInvoice;

public class GetInvoice
{
    public record Query(Guid OrderId) : IRequest<Invoice>;
}
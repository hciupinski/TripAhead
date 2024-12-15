using MediatR;

namespace TripAhead.Services.Orders.Application.Features.Orders.Queries.GetContract;

public class GetContract
{
    public record Query() : IRequest<GetContract>;
}
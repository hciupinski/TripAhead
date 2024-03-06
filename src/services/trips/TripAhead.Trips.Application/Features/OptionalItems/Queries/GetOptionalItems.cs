using MediatR;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;

namespace TripAhead.Trips.Application.Features.OptionalItems.Queries;

public class GetOptionalItems
{
    public record Query() : IRequest<List<OptionalItem>>;

    public class Handler(IOptionalItemRepository optionalItemRepository) : IRequestHandler<Query, List<OptionalItem>>
    {
        public async Task<List<OptionalItem>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await optionalItemRepository.GetAllAsync(cancellationToken);
        }
    }
}
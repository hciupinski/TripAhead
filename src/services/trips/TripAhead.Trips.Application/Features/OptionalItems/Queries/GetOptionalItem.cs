using MediatR;
using TripAhead.Trips.Application.Exceptions;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;

namespace TripAhead.Trips.Application.Features.OptionalItems.Queries;

public class GetOptionalItem
{
    public record Query(Guid Id) : IRequest<OptionalItem?>;

    public class Handler(IOptionalItemRepository optionalItemRepository) : IRequestHandler<Query, OptionalItem?>
    {
        public async Task<OptionalItem?> Handle(Query request, CancellationToken cancellationToken)
        {
            return await optionalItemRepository.FindAsync(request.Id, cancellationToken);
        }
    }
}
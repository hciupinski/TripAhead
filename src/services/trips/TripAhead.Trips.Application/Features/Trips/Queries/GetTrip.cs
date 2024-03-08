using MediatR;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;

namespace TripAhead.Trips.Application.Features.Trips.Queries;

public class GetTrip
{
    public record Query(Guid Id) : IRequest<Trip?>;

    public class Handler(ITripRepository tripRepository) : IRequestHandler<Query, Trip?>
    {
        public async Task<Trip?> Handle(Query request, CancellationToken cancellationToken)
        {
            return await tripRepository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
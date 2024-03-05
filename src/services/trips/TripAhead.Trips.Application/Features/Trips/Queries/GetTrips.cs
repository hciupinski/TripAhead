using MediatR;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;

namespace TripAhead.Trips.Application.Features.Trips.Queries;

public class GetTrips
{
    public record Query() : IRequest<List<Trip>>;

    public class Handler(ITripRepository tripRepository) : IRequestHandler<Query, List<Trip>>
    {
        public async Task<List<Trip>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await tripRepository.GetAllAsync(cancellationToken);
        }
    }
}
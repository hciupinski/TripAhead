using MediatR;
using Microsoft.EntityFrameworkCore;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.Trips.Queries.GetTrips;

public class GetTrips
{
    public record Query() : IRequest<TripsViewModel>;

    public class Handler(IApplicationDbContext context) : IRequestHandler<Query, TripsViewModel>
    {
        public async Task<TripsViewModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var tripItems = await context.Trips.Select(x => new TripItemDto(x.Id, x.Name))
                .ToListAsync(cancellationToken);
            return new TripsViewModel { Trips = tripItems };
        }
    }
}
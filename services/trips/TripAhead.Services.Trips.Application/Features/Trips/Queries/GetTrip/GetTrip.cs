using Ardalis.GuardClauses;
using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.Trips.Queries.GetTrip;

public class GetTrip
{
    public record Query(Guid Id) : IRequest<TripDetailsViewModel>;

    public class Handler(IApplicationDbContext context) : IRequestHandler<Query, TripDetailsViewModel>
    {
        public async Task<TripDetailsViewModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var tripDetails = await context.Trips.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, tripDetails);
            
            return new TripDetailsViewModel
            {
                Id = tripDetails.Id,
                Location = tripDetails.Location,
                Name = tripDetails.Name,
                DepartureTime = tripDetails.StartDate.DateTime,
                ArrivalTime = tripDetails.EndDate.DateTime,
            };
        }
    }
}
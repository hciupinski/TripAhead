using MediatR;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;

namespace TripAhead.Trips.Application.Features.Trips.Commands;

public class AddTrip
{
    public record Command(
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        int MaxOccupancy,
        decimal Price) : IRequest<Guid>;

    public class Handler(ITripRepository tripRepository) : IRequestHandler<Command, Guid>
    {
        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var trip = new Trip(
                request.Name,
                request.Description,
                request.StartDate,
                request.EndDate,
                request.MaxOccupancy,
                request.Price);

            await tripRepository.AddAsync(trip, cancellationToken);

            return trip.Id;
        }
    }
}
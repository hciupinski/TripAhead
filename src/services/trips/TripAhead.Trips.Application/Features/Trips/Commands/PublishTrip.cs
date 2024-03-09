using MediatR;
using TripAhead.Trips.Application.Exceptions;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;

namespace TripAhead.Trips.Application.Features.Trips.Commands;

public class PublishTrip
{
    public record Command(Guid Id) : IRequest;

    public class Handler(ITripRepository tripRepository) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var trip = await tripRepository.FindAsync(request.Id, cancellationToken);

            if (trip == null)
                throw new NotFoundException<OptionalItem>(request.Id);

            trip.Publish();

            await tripRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
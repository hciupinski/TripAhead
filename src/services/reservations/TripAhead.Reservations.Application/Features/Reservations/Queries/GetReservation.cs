using MediatR;
using TripAhead.Reservations.Domain.Models;
using TripAhead.Reservations.Domain.Repositories;

namespace TripAhead.Reservations.Application.Features.Reservations.Queries;

public class GetReservation
{
    public record Query(Guid TripId, Guid UserId) : IRequest<Reservation?>;

    public class Handler(IReservationRepository tripRepository) : IRequestHandler<Query, Reservation?>
    {
        public async Task<Reservation?> Handle(Query request, CancellationToken cancellationToken)
        {
            return await tripRepository.GetByIdentificationAsync(request.TripId, request.UserId, cancellationToken);
        }
    }
}
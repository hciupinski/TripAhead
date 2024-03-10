using MediatR;
using TripAhead.Reservations.Domain.Models;
using TripAhead.Reservations.Domain.Repositories;

namespace TripAhead.Reservations.Application.Features.Reservations.Queries;

public class GetReservations
{
    public record Query() : IRequest<List<Reservation>>;

    public class Handler(IReservationRepository tripRepository) : IRequestHandler<Query, List<Reservation>>
    {
        public async Task<List<Reservation>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await tripRepository.GetAllAsync(cancellationToken);
        }
    }
}
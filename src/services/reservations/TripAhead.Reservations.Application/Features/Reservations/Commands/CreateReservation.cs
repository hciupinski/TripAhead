using MediatR;
using TripAhead.Reservations.Domain.Exceptions;
using TripAhead.Reservations.Domain.Models;
using TripAhead.Reservations.Domain.Repositories;

namespace TripAhead.Reservations.Application.Features.Reservations.Commands;

public class CreateReservation
{
    public record Command(Guid TripId, Guid UserId, List<AdditionalOptionRequest> Options) : IRequest<Guid>;

    public record AdditionalOptionRequest(Guid OptionId, string Name, decimal Price);

    public class Handler(IReservationRepository reservationRepository) : IRequestHandler<Command, Guid>
    {
        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var exists = await reservationRepository.ExistsAsync(request.TripId, request.UserId, cancellationToken);
            if (exists)
                throw new ReservationExistsException(request.TripId, request.UserId);
            
            var reservation = new Reservation(request.TripId, request.UserId);

            reservation.SetAdditionalOptions(request.Options.Select(x => new AdditionalOption(x.OptionId, x.Name, x.Price)).ToList());

            await reservationRepository.AddAsync(reservation, cancellationToken);

            return reservation.Id;
        }
    }
}
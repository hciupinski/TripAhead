using MediatR;
using TripAhead.Trips.Application.Exceptions;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;

namespace TripAhead.Trips.Application.Features.Trips.Commands;

public class UpdateTrip
{
    public record Command(
        Guid Id,
        string Name,
        string Description,
        DateTimeOffset StartDate,
        DateTimeOffset EndDate,
        int MaxOccupancy,
        decimal Price,
        List<TripOptionalItemRequest> OptionalItems) : IRequest;

    public record TripOptionalItemRequest(Guid OptionalItemId, Guid? TripOptionalItemId, decimal? NewPrice);

    public class Handler(ITripRepository tripRepository, IOptionalItemRepository optionalItemRepository) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var trip = await tripRepository.GetByIdAsync(request.Id, cancellationToken) ??
                       throw new NotFoundException<Trip>(request.Id);

            var optionalItems = await optionalItemRepository.GetAllAsync(cancellationToken);

            var existingOptions =
                trip.Options.Where(toi => request.OptionalItems.Any(x => x.TripOptionalItemId == toi.Id));
            var newOptions = request.OptionalItems
                .Where(r => trip.Options.All(toi => toi.Id != r.TripOptionalItemId))
                .Select(x => new TripOptionalItem(trip, optionalItems.Single(o => o.Id == x.OptionalItemId)));

            var optionalItemsToAssign = existingOptions.Concat(newOptions).ToList();
            
            foreach (var priceRequest in request.OptionalItems.Where(r => r.NewPrice.HasValue))
            {
                optionalItemsToAssign.Single(o => o.OptionalItemId == priceRequest.OptionalItemId)
                    .SetPrice(priceRequest.NewPrice!.Value);
            }

            trip.Modify(request.Name, request.Description, request.MaxOccupancy)
                .SetDate(request.StartDate, request.EndDate)
                .SetPrice(request.Price)
                .AssignOptionalItems(optionalItemsToAssign);

            await tripRepository.UpdateAsync(trip, cancellationToken);
        }
    }
}
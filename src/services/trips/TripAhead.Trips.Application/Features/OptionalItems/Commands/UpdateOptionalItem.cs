using MediatR;
using TripAhead.Trips.Application.Exceptions;
using TripAhead.Trips.Domain.Enums;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;

namespace TripAhead.Trips.Application.Features.OptionalItems.Commands;

public class UpdateOptionalItem
{
    public record Command(
        Guid Id,
        string Name,
        string Description,
        decimal Price) : IRequest;

    public class Handler(IOptionalItemRepository optionalItemRepository) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var optionalItem = await optionalItemRepository.FindAsync(request.Id, cancellationToken) ??
                               throw new NotFoundException<OptionalItem>(request.Id);

            optionalItem
                .Modify(request.Name, request.Description)
                .SetPrice(request.Price);

            await optionalItemRepository.UpdateAsync(optionalItem, cancellationToken);
        }
    }
}
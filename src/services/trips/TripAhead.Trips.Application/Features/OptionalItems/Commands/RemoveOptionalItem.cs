using MediatR;
using TripAhead.Trips.Application.Exceptions;
using TripAhead.Trips.Domain.Enums;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;

namespace TripAhead.Trips.Application.Features.OptionalItems.Commands;

public class RemoveOptionalItem
{
    public record Command(Guid Id) : IRequest;

    public class Handler(IOptionalItemRepository optionalItemRepository) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var optionalItem = await optionalItemRepository.FindAsync(request.Id, cancellationToken);

            if (optionalItem == null)
                throw new NotFoundException<OptionalItem>(request.Id);
            
            await optionalItemRepository.DeleteAsync(optionalItem, cancellationToken);
        }
    }
}
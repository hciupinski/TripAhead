using MediatR;
using TripAhead.Trips.Domain.Enums;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;

namespace TripAhead.Trips.Application.Features.OptionalItems.Commands;

public class AddOptionalItem
{
    public record Command(
        OptionalItemType Type,
        string Name,
        string Description) : IRequest<Guid>;

    public class Handler(IOptionalItemRepository optionalItemRepository) : IRequestHandler<Command, Guid>
    {
        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var optionalItem = new OptionalItem(request.Type, request.Name, request.Description);

            await optionalItemRepository.AddAsync(optionalItem, cancellationToken);

            return optionalItem.Id;
        }
    }
}
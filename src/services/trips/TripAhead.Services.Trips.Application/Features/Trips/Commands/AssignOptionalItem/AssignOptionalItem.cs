using Ardalis.GuardClauses;
using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.Trips.Commands.AssignOptionalItem;

public class AssignOptionalItem
{
    public record Command(Guid Id, Guid OptionalItemId) : IRequest;

    public class Handler(IApplicationDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = await context.Trips.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);
            
            var optionalItem = await context.OptionalItems.FindAsync([request.OptionalItemId], cancellationToken);

            Guard.Against.NotFound(request.OptionalItemId, optionalItem);

            entity.AssignOptionalItem(optionalItem);
            
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
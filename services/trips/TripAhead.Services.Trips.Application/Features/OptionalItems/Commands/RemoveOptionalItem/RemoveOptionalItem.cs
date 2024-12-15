using Ardalis.GuardClauses;
using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.OptionalItems.Commands.RemoveOptionalItem;

public class RemoveOptionalItem
{
    public record Command(Guid Id) : IRequest;
    
    public class Handler(IApplicationDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = await context.OptionalItems.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);
            
            context.OptionalItems.Remove(entity);
            
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
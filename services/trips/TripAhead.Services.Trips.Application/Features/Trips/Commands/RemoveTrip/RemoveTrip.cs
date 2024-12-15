using Ardalis.GuardClauses;
using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.Trips.Commands.RemoveTrip;

public class RemoveTrip
{
    public record Command(Guid Id) : IRequest;

    public class Handler(IApplicationDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = await context.Trips.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);
            
            context.Trips.Remove(entity);
            
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
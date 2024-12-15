using Ardalis.GuardClauses;
using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.Trips.Commands.PublishTrip;

public class PublishTrip
{
    public record Command(Guid Id) : IRequest;

    public class Handler(IApplicationDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = await context.Trips.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            entity.Publish();
            
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
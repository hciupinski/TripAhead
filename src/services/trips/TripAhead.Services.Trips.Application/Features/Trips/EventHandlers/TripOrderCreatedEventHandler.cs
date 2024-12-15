using Ardalis.GuardClauses;
using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;
using TripAhead.Services.Trips.Domain.Events;

namespace TripAhead.Services.Trips.Application.Features.Trips.EventHandlers;

public class TripOrderCreatedEventHandler(IApplicationDbContext context) : INotificationHandler<TripOrderCreated>
{
    public async Task Handle(TripOrderCreated notification, CancellationToken cancellationToken)
    {
        var entity = await context.Trips.FindAsync([notification.TripId], cancellationToken);

        Guard.Against.NotFound(notification.TripId, entity);

        entity.AddOccupancy();

        context.Trips.Update(entity);
            
        await context.SaveChangesAsync(cancellationToken);;
    }
}
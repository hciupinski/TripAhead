using Ardalis.GuardClauses;
using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.Trips.Commands.UpdateTrip;

public class UpdateTrip 
{
    public record Command : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string Location { get; init; }
        public DateTimeOffset StartDate { get; init; }
        public DateTimeOffset EndDate { get; init; }
        public int MaxOccupancy { get; init; }
        public decimal Price { get; init; }
    }

    public class Handler(IApplicationDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = await context.Trips.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);
            
            entity
                .Modify(request.Name, request.Description, request.Location, request.MaxOccupancy)
                .SetDate(request.StartDate, request.EndDate)
                .SetPrice(request.Price);
            
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}

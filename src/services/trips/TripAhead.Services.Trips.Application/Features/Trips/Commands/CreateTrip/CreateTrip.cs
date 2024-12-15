using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;
using TripAhead.Services.Trips.Domain.Entities;

namespace TripAhead.Services.Trips.Application.Features.Trips.Commands.CreateTrip;

public class CreateTrip
{
    public record Command : IRequest<Guid>
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Location { get; init; }
        public DateTimeOffset StartDate { get; init; }
        public DateTimeOffset EndDate { get; init; }
        public int MaxOccupancy { get; init; }
        public decimal Price { get; init; }
    }

    public class Handler(IApplicationDbContext context) : IRequestHandler<Command, Guid>
    {
        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = new Trip(request.Name, request.Description, request.Location, request.StartDate, request.EndDate, request.MaxOccupancy, request.Price);
            
            context.Trips.Add(entity);
            
            await context.SaveChangesAsync(cancellationToken);
            
            return entity.Id;
        }
    }
}
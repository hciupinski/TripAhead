using Ardalis.GuardClauses;
using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.OptionalItems.Commands.UpdateOptionalItem;

public class UpdateOptionalItem
{
    public record Command() : IRequest
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    
    public class Handler(IApplicationDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = await context.OptionalItems.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);
            
            entity
                .Modify(request.Name, request.Description)
                .SetPrice(request.Price);
            
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
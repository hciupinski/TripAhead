using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;
using TripAhead.Services.Trips.Domain.Entities;
using TripAhead.Services.Trips.Domain.Enums;

namespace TripAhead.Services.Trips.Application.Features.OptionalItems.Commands.CreateOptionalItem;

public class CreateOptionalItem
{
    public record Command(string Name, string Description, OptionalItemType Type, decimal DefaultPrice) : IRequest<Guid>;
    
    public class Handler(IApplicationDbContext context) : IRequestHandler<Command, Guid>
    {
        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = new OptionalItem(request.Type, request.Name, request.Description, request.DefaultPrice);
            
            context.OptionalItems.Add(entity);
            
            await context.SaveChangesAsync(cancellationToken);
            
            return entity.Id;
        }
    }
}
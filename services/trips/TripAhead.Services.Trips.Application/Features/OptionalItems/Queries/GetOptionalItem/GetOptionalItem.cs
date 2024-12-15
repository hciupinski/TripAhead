using Ardalis.GuardClauses;
using MediatR;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.OptionalItems.Queries.GetOptionalItem;

public class GetOptionalItem
{
    public record Query(Guid Id) : IRequest<OptionalItemViewModel>;

    public class Handler(IApplicationDbContext context) : IRequestHandler<Query, OptionalItemViewModel>
    {
        public async Task<OptionalItemViewModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var optionalItem = await context.OptionalItems.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, optionalItem);
            
            return new OptionalItemViewModel()
            {
                Id = optionalItem.Id,
                Description = optionalItem.Description,
                Name = optionalItem.Name,
                Type = optionalItem.Type,
                Price = optionalItem.DefaultPrice,
            };
        }
    }
}
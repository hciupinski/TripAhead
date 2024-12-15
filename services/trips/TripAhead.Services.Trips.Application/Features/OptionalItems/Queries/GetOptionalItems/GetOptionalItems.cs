using MediatR;
using Microsoft.EntityFrameworkCore;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.OptionalItems.Queries.GetOptionalItems;

public class GetOptionalItems
{
    public record Query() : IRequest<OptionalItemsViewModel>;

    public class Handler(IApplicationDbContext context) : IRequestHandler<Query, OptionalItemsViewModel>
    {
        public async Task<OptionalItemsViewModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var tripItems = await context.OptionalItems.Select(x => new OptionalItemDto(x.Id, x.Name, x.Description, x.Type))
                .ToListAsync(cancellationToken);
            return new OptionalItemsViewModel { OptionalItems = tripItems };
        }
    }
}
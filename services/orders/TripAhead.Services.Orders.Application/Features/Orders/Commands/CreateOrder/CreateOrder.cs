using MediatR;
using TripAhead.Libs.Common.Interfaces;
using TripAhead.Services.Orders.Application.Interfaces;
using TripAhead.Services.Orders.Domain.Entities;

namespace TripAhead.Services.Orders.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrder
{
    public record Command(Guid TripId, List<OrderOption> Options) : IRequest<Guid>;

    public class Handler(IApplicationDbContext context, ITripsServiceClient tripsServiceClient, IUser user) : IRequestHandler<Command, Guid>
    {
        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                CustomerId = user.Id ?? throw new Exception("Cannot create customer from an empty order"),
                TripId = request.TripId,
                Options = request.Options
            };
            
            
            
            await tripsServiceClient.NotifyNewOrderAsync(order.Id, order.TripId);
            
            throw new NotImplementedException();
        }
    }
}
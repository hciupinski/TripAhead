using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TripAhead.Services.Orders.Application.Features.Orders.Commands.CancelOrder;
using TripAhead.Services.Orders.Application.Features.Orders.Commands.CreateOrder;
using TripAhead.Services.Orders.Application.Features.Orders.Queries.GetInvoice;
using TripAhead.Services.Orders.Application.Features.Orders.Queries.GetOrder;
using TripAhead.Services.Orders.Application.Features.Orders.Queries.GetOrders;
using TripAhead.Services.Orders.Domain.Entities;
using TripsService;

namespace TripAhead.Services.Orders.API.Endpoints;

public static class OrdersEndpoints
{
    public static IEndpointRouteBuilder MapOrdersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAllOrders);
        app.MapGet("/{id:guid}", GetOrderDetails);
        app.MapGet("/{id:guid}/invoice", GetOrderInvoice);
        //app.MapGet("/{id:guid}/contract", GetOrderContract);
        
        app.MapPut("/create", CreateOrder);
        app.MapDelete("/cancel/{id:guid}", CancelOrder);
        
        return app;
    }
    
    public static async Task<Results<Ok<Order[]>, BadRequest<string>>> GetAllOrders(
        [FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new GetOrders.Query());

        return TypedResults.Ok(results);
    }

    public static async Task<Results<Ok<Order>, NotFound>> GetOrderDetails(
        [FromServices] IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetOrder.Query(id));

        return TypedResults.Ok(result);
    }
    
    public static async Task<Results<Ok<Invoice>, NotFound>> GetOrderInvoice(
        [FromServices] IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetInvoice.Query(id));

        return TypedResults.Ok(result);
    }
    
    public static async Task<Created> CreateOrder(
        [FromServices] IMediator mediator,
        [FromServices] Trips.TripsClient tripsClient,
        [FromBody] CreateOrder.Command request)
    {
        var orderId = await mediator.Send(request);
        
        await tripsClient.NotifyNewOrderAsync(new NewOrderRequest() { OrderId = orderId.ToString() });
        
        return TypedResults.Created($"/api/v1/orders/{orderId}");
    }
    
    public static async Task<Ok> CancelOrder(
        [FromServices] IMediator mediator,
        Guid id)
    {
        await mediator.Send(new CancelOrder.Command(id));
        return TypedResults.Ok();
    }
}
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TripAhead.Services.Trips.Application.Features.OptionalItems.Commands.CreateOptionalItem;
using TripAhead.Services.Trips.Application.Features.OptionalItems.Commands.RemoveOptionalItem;
using TripAhead.Services.Trips.Application.Features.OptionalItems.Commands.UpdateOptionalItem;
using TripAhead.Services.Trips.Application.Features.OptionalItems.Queries.GetOptionalItem;
using TripAhead.Services.Trips.Application.Features.OptionalItems.Queries.GetOptionalItems;

namespace TripAhead.Services.Trips.API.Endpoints;

public static class OptionalItemsEndpoints
{
    public static IEndpointRouteBuilder MapOptionalItemsEndpoints(this IEndpointRouteBuilder app)
    {
        var manageGroup = app.MapGroup("manage").RequireAuthorization(a => a.RequireRole("Admin"));
        
        manageGroup.MapGet("/", GetAllOptionalItems);
        manageGroup.MapGet("/{id:guid}", GetOptionalItem);
        
        manageGroup.MapPut("/create", CreateOptionalItem);
        manageGroup.MapPost("/{id:guid}", UpdateOptionalItem);
        manageGroup.MapDelete("/{id:guid}", RemoveOptionalItem);
        
        return app;
    }
    
    public static async Task<Results<Ok<OptionalItemsViewModel>, BadRequest<string>>> GetAllOptionalItems([FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new GetOptionalItems.Query());

        return TypedResults.Ok(results);
    }
    
    public static async Task<Results<Ok<OptionalItemViewModel>, NotFound>> GetOptionalItem(
        [FromServices] IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetOptionalItem.Query(id));

        return TypedResults.Ok(result);
    }
    
    public static async Task<Created> CreateOptionalItem(
        [FromServices] IMediator mediator,
        [FromBody]CreateOptionalItem.Command request)
    {
        var optionalItemId = await mediator.Send(request);
        return TypedResults.Created($"/api/v1/optional-items/{optionalItemId}");
    }
    
    public static async Task<Ok> UpdateOptionalItem(
        [FromServices] IMediator mediator,
        [FromBody]UpdateOptionalItem.Command request)
    {
        await mediator.Send(request);
        return TypedResults.Ok();
    }
    
    public static async Task<Ok> RemoveOptionalItem(
        [FromServices] IMediator mediator,
        Guid id)
    {
        await mediator.Send(new RemoveOptionalItem.Command(id));
        return TypedResults.Ok();
    }
    
}
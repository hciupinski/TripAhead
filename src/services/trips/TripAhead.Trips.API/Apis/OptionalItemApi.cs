using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TripAhead.Trips.Application.Features.OptionalItems.Commands;
using TripAhead.Trips.Application.Features.OptionalItems.Queries;
using TripAhead.Trips.Domain.Models;

namespace TripAhead.Trips.API.Apis;

public static class OptionalItemApi
{
    public static IEndpointRouteBuilder MapOptionalItemApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAllOptionalItems);
        app.MapGet("/{id}", GetAllOptionalItems);
        
        app.MapPut("/", CreateOptionalItem);
        app.MapPost("/{id}", UpdateOptionalItem);
        app.MapDelete("/{id}", RemoveOptionalItem);
        
        return app;
    }

    public static async Task<Results<Ok<List<OptionalItem>>, BadRequest<string>>> GetAllOptionalItems([FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new GetOptionalItems.Query());

        return TypedResults.Ok(results);
    }
    
    public static async Task<Results<Ok<OptionalItem>, NotFound>> GetOptionalItem(
        [FromServices] IMediator mediator,
        [FromQuery] Guid id)
    {
        var result = await mediator.Send(new GetOptionalItem.Query(id));

        if (result == null)
            return TypedResults.NotFound();

        return TypedResults.Ok(result);
    }

    public static async Task<Created> CreateOptionalItem(
        [FromServices] IMediator mediator,
        [FromBody]AddOptionalItem.Command request)
    {
        var optionalItem = await mediator.Send(request);
        return TypedResults.Created();
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
        [FromQuery] Guid id)
    {
        await mediator.Send(new RemoveOptionalItem.Command(id));
        return TypedResults.Ok();
    }
}
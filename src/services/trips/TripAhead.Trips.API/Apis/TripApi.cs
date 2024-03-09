using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TripAhead.Trips.Application.Features.Trips.Commands;
using TripAhead.Trips.Application.Features.Trips.Queries;
using TripAhead.Trips.Domain.Models;

namespace TripAhead.Trips.API.Apis;

public static class TripApi
{
    public static IEndpointRouteBuilder MapTripApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAllTrips);
        app.MapGet("/{id:guid}", GetTrip);
        
        app.MapPut("/", CreateTrip);
        app.MapPost("/{id:guid}", UpdateTrip);
        app.MapDelete("/{id:guid}", RemoveTrip);

        app.MapPost("/publish/{id:guid}", PublishTrip);
        
        return app;
    }

    public static async Task<Results<Ok<List<Trip>>, BadRequest<string>>> GetAllTrips([FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new GetTrips.Query());

        return TypedResults.Ok(results);
    }
    
    public static async Task<Results<Ok<Trip>, NotFound>> GetTrip(
        [FromServices] IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetTrip.Query(id));

        if (result == null)
            return TypedResults.NotFound();

        return TypedResults.Ok(result);
    }

    public static async Task<Created> CreateTrip(
        [FromServices] IMediator mediator,
        [FromBody]AddTrip.Command request)
    {
        var tripId = await mediator.Send(request);
        return TypedResults.Created($"/api/v1/trips/{tripId}");
    }
    
    public static async Task<Ok> UpdateTrip(
        [FromServices] IMediator mediator,
        [FromBody]UpdateTrip.Command request)
    {
        await mediator.Send(request);
        return TypedResults.Ok();
    }
    
    public static async Task<Ok> RemoveTrip(
        [FromServices] IMediator mediator,
        Guid id)
    {
        await mediator.Send(new RemoveTrip.Command(id));
        return TypedResults.Ok();
    }
    
    public static async Task<Ok> PublishTrip(
        [FromServices] IMediator mediator,
        Guid id)
    {
        await mediator.Send(new PublishTrip.Command(id));
        return TypedResults.Ok();
    }
}
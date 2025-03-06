using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TripAhead.Services.Trips.Application.Features.Trips.Commands.AssignOptionalItem;
using TripAhead.Services.Trips.Application.Features.Trips.Commands.CreateTrip;
using TripAhead.Services.Trips.Application.Features.Trips.Commands.PublishTrip;
using TripAhead.Services.Trips.Application.Features.Trips.Commands.RemoveTrip;
using TripAhead.Services.Trips.Application.Features.Trips.Commands.UpdateTrip;
using TripAhead.Services.Trips.Application.Features.Trips.Queries.GetTrip;
using TripAhead.Services.Trips.Application.Features.Trips.Queries.GetTrips;

namespace TripAhead.Services.Trips.API.Endpoints;

public static class TripsEndpoints
{
    public static IEndpointRouteBuilder MapTripsEndpoints(this IEndpointRouteBuilder app)
    {
        // app.MapGet("/", GetAllTrips);
        app.MapGet("/{id:guid}", GetTrip);

        var manageGroup = app.MapGroup("manage").RequireAuthorization("admin");
        manageGroup.MapGet("/", GetAllTrips);
        manageGroup.MapPut("/create", CreateTrip);
        manageGroup.MapPost("/{id:guid}", UpdateTrip);
        manageGroup.MapDelete("/{id:guid}", RemoveTrip);
        manageGroup.MapPost("/publish/{id:guid}", PublishTrip);
        manageGroup.MapPost("/{id:guid}/optional-items/{optionalItemId:guid}/assign", AssignOptionalItem);

        return app;
    }

    public static async Task<Results<Ok<TripsViewModel>, BadRequest<string>>> GetAllTrips(
        [FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new GetTrips.Query());

        return TypedResults.Ok(results);
    }

    public static async Task<Results<Ok<TripDetailsViewModel>, NotFound>> GetTrip(
        [FromServices] IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetTrip.Query(id));

        return TypedResults.Ok(result);
    }

    public static async Task<Created> CreateTrip(
        [FromServices] IMediator mediator,
        [FromBody] CreateTrip.Command request)
    {
        var tripId = await mediator.Send(request);
        return TypedResults.Created($"/api/v1/trips/{tripId}");
    }

    public static async Task<Ok> UpdateTrip(
        [FromServices] IMediator mediator,
        [FromBody] UpdateTrip.Command request)
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

    public static async Task<Ok> AssignOptionalItem(
        [FromServices] IMediator mediator,
        Guid id,
        Guid optionalItemId)
    {
        await mediator.Send(new AssignOptionalItem.Command(id, optionalItemId));
        return TypedResults.Ok();
    }
}
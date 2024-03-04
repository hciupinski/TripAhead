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
        app.MapPut("/", CreateTrip);
        
        return app;
    }

    public static async Task<Results<Ok<List<Trip>>, BadRequest<string>>> GetAllTrips([AsParameters] IMediator mediator)
    {
        var results = await mediator.Send(new GetTrips.Query());

        return TypedResults.Ok(results);
    }

    public static async Task<Created> CreateTrip(
        [FromBody]AddTrip.Command request,
        [AsParameters] IMediator mediator)
    {
        var tripId = await mediator.Send(request);
        return TypedResults.Created($"/api/v1/trips/{tripId}");
    }
}
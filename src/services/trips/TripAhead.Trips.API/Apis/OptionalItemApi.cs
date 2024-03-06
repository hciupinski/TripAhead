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
        app.MapPut("/", CreateTrip);
        
        return app;
    }

    public static async Task<Results<Ok<List<OptionalItem>>, BadRequest<string>>> GetAllOptionalItems([FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new GetOptionalItems.Query());

        return TypedResults.Ok(results);
    }

    public static async Task<Created> CreateTrip(
        [FromServices] IMediator mediator,
        [FromBody]AddOptionalItem.Command request)
    {
        var optionalItem = await mediator.Send(request);
        return TypedResults.Created();
    }
}
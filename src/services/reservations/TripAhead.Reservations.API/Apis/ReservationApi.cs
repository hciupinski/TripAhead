using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TripAhead.Reservations.Application.Features.Reservations.Commands;
using TripAhead.Reservations.Application.Features.Reservations.Queries;
using TripAhead.Reservations.Domain.Models;

namespace TripAhead.Reservations.API.Apis;

public static class ReservationApi
{
    public static IEndpointRouteBuilder MapReservationApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAllReservations);

        app.MapPut("/create", CreateReservation);
        
        return app;
    }

    public static async Task<Results<Ok<List<Reservation>>, BadRequest<string>>> GetAllReservations([FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new GetReservations.Query());

        return TypedResults.Ok(results);
    }
    
    public static async Task<Created> CreateReservation(
        [FromServices] IMediator mediator,
        [FromBody]CreateReservation.Command request)
    {
        var reservationId = await mediator.Send(request);
        return TypedResults.Created($"/api/v1/reservations/{reservationId}");
    }
}
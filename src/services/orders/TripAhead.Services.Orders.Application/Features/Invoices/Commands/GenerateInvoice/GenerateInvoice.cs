using MediatR;

namespace TripAhead.Services.Orders.Application.Features.Invoices.Commands.GenerateInvoice;

public class GenerateInvoice
{
    public record Command() : IRequest;
}
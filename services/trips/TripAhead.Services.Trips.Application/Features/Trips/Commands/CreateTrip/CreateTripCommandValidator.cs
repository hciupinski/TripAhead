using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.Trips.Commands.CreateTrip;

public class CreateTripCommandValidator : AbstractValidator<CreateTrip.Command>
{
    private readonly IApplicationDbContext _context;
    public CreateTripCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(BeUniqueName)
                .WithMessage("Trip name must be unique")
                .WithErrorCode("Unique");
    }
    
    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return !await _context.Trips
            .AnyAsync(l => l.Name == name, cancellationToken);
    }
}
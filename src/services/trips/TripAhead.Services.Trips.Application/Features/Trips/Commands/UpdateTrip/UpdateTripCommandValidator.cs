using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TripAhead.Services.Trips.Application.Interfaces;

namespace TripAhead.Services.Trips.Application.Features.Trips.Commands.UpdateTrip;

public class UpdateTripCommandValidator : AbstractValidator<UpdateTrip.Command>
{
    private readonly IApplicationDbContext _context;
    public UpdateTripCommandValidator(IApplicationDbContext context)
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
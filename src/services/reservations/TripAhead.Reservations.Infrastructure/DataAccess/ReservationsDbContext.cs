using MediatR;
using Microsoft.EntityFrameworkCore;
using TripAhead.Common;
using TripAhead.Reservations.Domain.Models;
using TripAhead.Reservations.Infrastructure.DataAccess.Converters;
using TripAhead.Reservations.Infrastructure.DataAccess.EntityConfigurations;

namespace TripAhead.Reservations.Infrastructure.DataAccess;

public class ReservationsDbContext(DbContextOptions<ReservationsDbContext> options, IPublisher publisher) : DbContext(options)
{
    public DbSet<Reservation> Reservations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("reservations");

        builder.ApplyConfiguration(new ReservationEntityConfiguration());
        builder.ApplyConfiguration(new InvoiceEntityConfiguration());
        builder.ApplyConfiguration(new LineItemEntityConfiguration());
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetConverter>();
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker.Entries<Entity>()
            .SelectMany(entry => entry.Entity.TakeEvents())
            .ToList();

        await PublishDomainEvents(domainEvents);
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    private async Task PublishDomainEvents(List<IDomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            await publisher.Publish(domainEvent);
        }
    }
}
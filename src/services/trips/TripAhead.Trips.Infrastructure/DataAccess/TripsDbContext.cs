using MediatR;
using Microsoft.EntityFrameworkCore;
using TripAhead.Common;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Infrastructure.DataAccess.EntityConfigurations;

namespace TripAhead.Trips.Infrastructure.DataAccess;

public class TripsDbContext(DbContextOptions<TripsDbContext> options, IPublisher publisher) : DbContext(options)
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<OptionalItem> OptionalItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("trips");
        builder.ApplyConfiguration(new TripEntityConfiguration());
        builder.ApplyConfiguration(new OptionalItemEntityConfiguration());
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
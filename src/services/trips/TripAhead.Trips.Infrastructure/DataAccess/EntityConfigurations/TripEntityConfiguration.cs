using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripAhead.Trips.Domain.Models;

namespace TripAhead.Trips.Infrastructure.DataAccess.EntityConfigurations;

public class TripEntityConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.ToTable(nameof(Trip));

        builder.Property(t => t.Id)
            .ValueGeneratedNever();

        builder.Property(t => t.Name)
            .HasMaxLength(50);
        builder.Property(t => t.Description)
            .HasMaxLength(350);

        builder.HasMany(t => t.Options)
            .WithOne(o => o.Trip)
            .HasPrincipalKey(t => t.Id)
            .HasForeignKey(o => o.TripId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
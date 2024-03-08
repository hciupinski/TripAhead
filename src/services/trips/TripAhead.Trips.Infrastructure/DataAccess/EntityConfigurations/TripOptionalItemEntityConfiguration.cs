using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripAhead.Trips.Domain.Models;

namespace TripAhead.Trips.Infrastructure.DataAccess.EntityConfigurations;

public class TripOptionalItemEntityConfiguration : IEntityTypeConfiguration<TripOptionalItem>
{
    public void Configure(EntityTypeBuilder<TripOptionalItem> builder)
    {
        builder.ToTable(nameof(TripOptionalItem));

        builder.HasOne(toi => toi.Trip)
            .WithMany(t => t.Options)
            .HasPrincipalKey(t => t.Id)
            .HasForeignKey(toi => toi.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(toi => toi.OptionalItem)
            .WithMany()
            .HasPrincipalKey(o => o.Id)
            .HasForeignKey(toi => toi.OptionalItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
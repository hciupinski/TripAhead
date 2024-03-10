using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripAhead.Reservations.Domain.Models;

namespace TripAhead.Reservations.Infrastructure.DataAccess.EntityConfigurations;

public class ReservationEntityConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable(nameof(Reservation));

        builder.Property(t => t.Id)
            .ValueGeneratedNever();

        builder.HasOne(r => r.Invoice)
            .WithOne(i => i.Reservation)
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsMany(
            x => x.AdditionalOptions,
            ao => ao.ToJson());
    }
}
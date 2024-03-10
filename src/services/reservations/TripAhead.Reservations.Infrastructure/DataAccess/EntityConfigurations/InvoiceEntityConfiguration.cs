using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripAhead.Reservations.Domain.Models.Invoice;

namespace TripAhead.Reservations.Infrastructure.DataAccess.EntityConfigurations;

public class InvoiceEntityConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable(nameof(Invoice));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.IssueDate).IsRequired();
        builder.Property(x => x.DueDate).IsRequired();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        builder.Property(x => x.InvoiceNumber).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Comments).HasMaxLength(450);
        builder.Property(x => x.FilePath).HasMaxLength(500);

        builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(x => x.InvoiceId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

namespace OnlineCaterer.Data.Configurations;

public class BookingConfig : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.BookingId);

        builder.HasOne(b => b.Customer)
            .WithMany(c => c.Bookings)
            .HasForeignKey(b => b.CustomerId)
            .IsRequired();

        builder.HasOne(b => b.Caterer)
            .WithMany(c => c.Bookings)
            .HasForeignKey(b => b.CatererId)
            .IsRequired();

        builder.Property(b => b.TotalAmount)
            .HasColumnType("money")
            .IsRequired();

        builder.Property(b => b.EventDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(b => b.BookingDate)
            .HasColumnType("datetime2")
            .HasDefaultValue(DateTime.Now)
            .IsRequired();

    }
}


namespace OnlineCaterer.Data.Configurations;

public class BookingDetailsConfig : IEntityTypeConfiguration<BookingDetails>
{
    public void Configure(EntityTypeBuilder<BookingDetails> builder)
    {
        
        builder.HasKey(bd => new { bd.BookingId, bd.FoodId });

        builder.HasOne(bd => bd.Booking)
            .WithMany(b => b.Details)
            .HasForeignKey(bd => bd.BookingId)
            .IsRequired();

        builder.HasOne(bd => bd.Food)
            .WithMany(b => b.BookingDetails)
            .HasForeignKey(bd => bd.FoodId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(b => b.UnitPrice)
            .HasColumnType("money")
            .IsRequired();

        builder.Property(bd => bd.Quantity)
            .HasDefaultValue(1)
            .IsRequired();

        builder.Property(b => b.Discount)
            .HasColumnType("real")
            .HasDefaultValue(0)
            .IsRequired();

    }
}

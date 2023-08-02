
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Entities;

namespace OnlineCaterer.Data.Configurations;

public class BookingDetailsConfig : IEntityTypeConfiguration<BookingDetails>
{
    public void Configure(EntityTypeBuilder<BookingDetails> builder)
    {
        
        builder.HasKey(bd => new { bd.BookingId, bd.FoodId });
     
        //builder.HasOne(bd => bd.Food).WithMany(bd => bd.BookingDetails).HasPrincipalKey(f => f.FoodId);
    }
}

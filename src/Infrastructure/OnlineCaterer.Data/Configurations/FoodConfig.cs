using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Entities;

namespace OnlineCaterer.Data.Configurations;

public class FoodConfig : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.HasIndex(x => x.CategoryId).IsUnique();

        //builder.HasKey(f => new { f.FoodId, f.CategoryId });

//        builder.HasMany(f => f.BookingDetails).WithOne(bd => bd.Food).HasPrincipalKey(bd => bd.FoodId);
    }
}

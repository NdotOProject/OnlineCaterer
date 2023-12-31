﻿
namespace OnlineCaterer.Data.Configurations;

public class FoodConfig : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.HasKey(f => f.FoodId);

        builder.Property(f => f.Name)
            .HasColumnType("nvarchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(f => f.QuantityPerUnit)
            .HasColumnType("nvarchar(40)")
            .IsRequired();

        builder.Property(f => f.Description)
            .HasColumnType("nvarchar(max)")
            .HasDefaultValue("No Description");

        builder.Property(f => f.Price)
            .HasColumnType("money")
            .IsRequired();

        builder.Property(f => f.Discontinued)
            .HasDefaultValue(false)
            .IsRequired();
    }
}

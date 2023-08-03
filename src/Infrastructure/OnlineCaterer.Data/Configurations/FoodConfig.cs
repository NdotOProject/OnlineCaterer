
namespace OnlineCaterer.Data.Configurations;

public class FoodConfig : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.HasKey(f => f.FoodId);

        builder.HasIndex(x => x.CategoryId)
            .IsUnique();

        builder.HasOne(f => f.Category)
            .WithMany(ft => ft.Foods)
            .HasForeignKey(f => f.CategoryId)
            .IsRequired();

        builder.Property(f => f.Name)
            .HasColumnType("nvarchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(f => f.Description)
            .HasColumnType("nvarchar(max)")
            .HasDefaultValue("No Description");

        builder.Property(f => f.Price)
            .HasColumnType("money")
            .IsRequired();
    }
}

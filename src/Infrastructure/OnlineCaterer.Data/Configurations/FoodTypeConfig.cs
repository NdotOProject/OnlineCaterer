
namespace OnlineCaterer.Data.Configurations;

public class FoodTypeConfig : IEntityTypeConfiguration<FoodType>
{
    public void Configure(EntityTypeBuilder<FoodType> builder)
    {
        builder.HasKey(ft => ft.Id);

        builder.Property(ft => ft.Name)
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(ft => ft.Description)
            .HasColumnType("nvarchar(max)")
            .HasDefaultValue("No Description");

        builder.HasOne(ft => ft.Caterer)
            .WithMany(ft => ft.FoodTypes)
            .HasForeignKey(ft => ft.CatererId);

        builder.HasMany(ft => ft.Foods)
            .WithOne(f => f.Category)
            .HasForeignKey(f => f.CategoryId)
            .IsRequired();

    }
}

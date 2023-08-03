
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

        builder.HasIndex(ft => ft.Name)
            .IsUnique();

        builder.Property(ft => ft.Description)
            .HasColumnType("nvarchar(max)")
            .HasDefaultValue("No Description");

    }
}

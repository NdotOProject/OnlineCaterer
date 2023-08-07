
namespace OnlineCaterer.Data.Configurations;

public class PlaceConfig : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("nvarchar")
            .HasMaxLength(500)
            .IsRequired();

    }
}

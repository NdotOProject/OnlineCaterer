
namespace OnlineCaterer.Data.Configurations;

public class CatererConfig : IEntityTypeConfiguration<Caterer>
{
    public void Configure(EntityTypeBuilder<Caterer> builder)
    {
        builder.Ignore("BaseUser");

        builder.HasKey(c => c.UserId);

        builder.Property(c => c.UserId)
            .HasColumnType("nvarchar")
            .HasMaxLength(450)
            .ValueGeneratedNever();

        builder.Property(c => c.Name)
            .HasColumnType("nvarchar(500)")
            .IsRequired();

        builder.Property(c => c.Address)
            .HasColumnType("nvarchar(500)")
            .IsRequired();

        builder.Property(c => c.IntroduceMessage)
            .HasColumnType("nvarchar")
            .HasMaxLength(1000)
            .HasDefaultValue("Welcome");

    }
}

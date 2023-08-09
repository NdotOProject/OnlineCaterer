
namespace OnlineCaterer.Data.Configurations;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Ignore("BaseUser");

        builder.HasKey(c => c.UserId);

        builder.Property(c => c.UserId)
            .HasColumnType("nvarchar")
            .HasMaxLength(450)
            .ValueGeneratedNever();

        builder.Property(c => c.Name)
            .HasColumnType("nvarchar(500)");

        builder.Property(c => c.Address)
            .HasColumnType("nvarchar(500)");

    }
}

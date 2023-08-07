
namespace OnlineCaterer.Data.Configurations;

public class UserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {

        builder.HasOne<Caterer>()
            .WithOne()
            .HasForeignKey<Caterer>(ca => ca.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<Customer>()
            .WithOne()
            .HasForeignKey<Customer>(cus => cus.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

    }
}

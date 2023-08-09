
namespace OnlineCaterer.Data.Configurations;

public class ResponseMessageConfig : IEntityTypeConfiguration<ResponseMessage>
{
    public void Configure(EntityTypeBuilder<ResponseMessage> builder)
    {
        builder.HasKey(rm => rm.Id);

        builder.HasOne(rm => rm.Caterer)
            .WithMany(c => c.ResponseMessages)
            .HasForeignKey(rm => rm.CatererId)
            .IsRequired();

        builder.Property(rm => rm.Title)
            .HasColumnType("nvarchar")
            .HasMaxLength(500)
            .HasDefaultValue("Thank You So Much!");

        builder.Property(rm => rm.Content)
            .HasColumnType("nvarchar(max)")
            .HasDefaultValue("Thank you for using our service!");

        builder.Property(rm => rm.ResponseDate)
            .HasColumnType("date")
            .HasDefaultValue(null);

    }
}

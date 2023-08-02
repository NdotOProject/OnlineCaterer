
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Entities;

namespace OnlineCaterer.Data.Configurations;

public class CatererConfig : IEntityTypeConfiguration<Caterer>
{
    public void Configure(EntityTypeBuilder<Caterer> builder)
    {
        builder.Property(c => c.UserId)
            .ValueGeneratedNever();
    }
}

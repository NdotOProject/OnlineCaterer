
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Data.Identity;
using OnlineCaterer.Domain.Entities;

namespace OnlineCaterer.Data.Configurations;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.UserId)
            .ValueGeneratedNever();
    }
}

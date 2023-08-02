
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Data.Configurations;
using OnlineCaterer.Data.Identity;
using OnlineCaterer.Domain.Entities;
using System.Reflection;

namespace OnlineCaterer.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);

        builder.AddIdentityModelsConfig();

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookingDetails> BookingsDetails { get; set; }
    public DbSet<Caterer> Caterers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodType> FoodTypes { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<ResponseMessage> ResponseMessages { get; set; }

}


using System.Reflection;

namespace OnlineCaterer.Data.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser> , IApplicationDbContext
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
/*
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            entry.Entity.LastModifiedDate = DateTime.Now;

            if (entry.State == EntityState.Modified)
            {
            
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
*/
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<BookingDetails> BookingsDetails => Set<BookingDetails>();
    public DbSet<Caterer> Caterers => Set<Caterer>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Food> Foods => Set<Food>();
    public DbSet<FoodType> FoodTypes => Set<FoodType>();
    public DbSet<Place> Places => Set<Place>();
    public DbSet<ResponseMessage> ResponseMessages => Set<ResponseMessage>();

}

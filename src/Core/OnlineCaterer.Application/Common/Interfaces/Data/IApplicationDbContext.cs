
namespace OnlineCaterer.Application.Common.Interfaces.Data;

public interface IApplicationDbContext
{
    public DbSet<Booking> Bookings { get; }
    public DbSet<BookingDetails> BookingsDetails { get; }
    public DbSet<Caterer> Caterers { get; }
    public DbSet<Customer> Customers { get; }
    public DbSet<Food> Foods { get; }
    public DbSet<FoodType> FoodTypes { get; }
    public DbSet<Place> Places { get; }
    public DbSet<ResponseMessage> ResponseMessages { get; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}


using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Domain.Entities;

namespace OnlineCaterer.Application.Common.Interfaces;

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

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}

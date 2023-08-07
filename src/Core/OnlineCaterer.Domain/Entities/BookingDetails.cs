
namespace OnlineCaterer.Domain.Entities;

public class BookingDetails
{
    public int BookingId { get; set; }
    public Booking? Booking { get; set; }

    public int FoodId { get; set; }
    public Food? Food { get; set; }

    public int Quantity { get; set; }

}

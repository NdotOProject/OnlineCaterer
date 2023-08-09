
namespace OnlineCaterer.Domain.Entities;

public class BookingDetails
{
    // FK_BookingDetails_Booking
    public int BookingId { get; set; }
    public Booking Booking { get; set; }
    // FK_BookingDetails_Food
    public int FoodId { get; set; }
    public Food Food { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public float Discount { get; set; }

}

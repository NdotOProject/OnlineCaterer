
namespace OnlineCaterer.Domain.Entities;

public class Booking
{
    // PK
    public int BookingId { get; set; }
    // FK_Booking_Customer
    public string CustomerId { get; set; }
    public Customer Customer { get; set; }
    // FK_Booking_Caterer
    public string CatererId { get; set; }
    public Caterer Caterer { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime EventDate { get; set; }

    public DateTime BookingDate { get; set; }

    public ICollection<BookingDetails> Details { get; set; } = new HashSet<BookingDetails>();

}


namespace OnlineCaterer.Domain.Entities;

public class Booking
{
    public int BookingId { get; set; }

    public string? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public string? CatererId { get; set; }
    public Caterer? Caterer { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime EventDate { get; set; }

    public DateTime BookingDate { get; set; }

    public ICollection<BookingDetails> Details { get; set; } = new HashSet<BookingDetails>();

}

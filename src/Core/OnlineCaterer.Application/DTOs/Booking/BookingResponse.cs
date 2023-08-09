
namespace OnlineCaterer.Application.DTOs.Booking;

public class BookingResponse
{
    public int BookingId { get; set; }

    public SimpleCustomerResponse? Customer { get; set; }

    public SimpleCatererResponse? Caterer { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime EventDate { get; set; }

    public DateTime BookingDate { get; set; }

    //public ICollection<BookingDetailsResponse>? Details { get; set; }

}

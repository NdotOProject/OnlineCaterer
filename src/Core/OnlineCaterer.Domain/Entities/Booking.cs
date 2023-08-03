
namespace OnlineCaterer.Domain.Entities;

public class Booking
{
    //[Key]
    public int BookingId { get; set; }

    //[Required]
    //[ForeignKey(nameof(Customer))]
    public string? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    //[Required]
    //[ForeignKey(nameof(Caterer))]
    public string? CatererId { get; set; }
    public Caterer? Caterer { get; set; }

    //[Required]
    //[DataType(DataType.Currency)]
    public decimal TotalAmount { get; set; }

    //[Required]
    //[DataType(DataType.DateTime)]
    public DateTime EventDate { get; set; }

    //[Required]
    //[DataType(DataType.DateTime)]
    public DateTime BookingDate { get; set; }// = DateTime.Now;

    public ICollection<BookingDetails> Details { get; set; } = new HashSet<BookingDetails>();

}

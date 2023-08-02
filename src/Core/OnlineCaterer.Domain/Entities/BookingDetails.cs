
using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Entities;

public class BookingDetails : BaseEntity
{
    [ForeignKey(nameof(Booking))]
    public int BookingId { get; set; }
    public Booking? Booking { get; set; }

    [ForeignKey(nameof(Food))]
    public int FoodId { get; set; }
    public Food? Food { get; set; }

    [Required]
    public int Quantity { get; set; }

}

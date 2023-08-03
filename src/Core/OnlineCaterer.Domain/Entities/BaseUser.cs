
namespace OnlineCaterer.Domain.Entities;

public class BaseUser : BaseEntity
{
    public string? UserId { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

}

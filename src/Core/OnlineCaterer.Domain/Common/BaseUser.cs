
namespace OnlineCaterer.Domain.Common;

public class BaseUser : BaseEntity
{
    public string UserId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

}

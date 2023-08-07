
namespace OnlineCaterer.Domain.Entities;

public class Food : BaseEntity
{
    public int FoodId { get; set; }

    public int CategoryId { get; set; }
    public FoodType Category { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public ICollection<BookingDetails> BookingDetails { get; set; } = new HashSet<BookingDetails>();

}

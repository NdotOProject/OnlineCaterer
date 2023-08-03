
using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Entities;

public class Food : BaseEntity
{
    //[Key]
    public int FoodId { get; set; }

    //[ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public FoodType? Category { get; set; }

    //[Required]
    //[StringLength(255)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    //[Required]
    //[DataType(DataType.Currency)]
    public decimal Price { get; set; }

    public ICollection<BookingDetails> BookingDetails { get; set; } = new HashSet<BookingDetails>();

}

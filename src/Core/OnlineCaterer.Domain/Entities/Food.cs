
namespace OnlineCaterer.Domain.Entities;

public class Food : BaseEntity
{
    // PK
    public int FoodId { get; set; }
    // FK_Food_FoodType
    public int CategoryId { get; set; }
    public FoodType Category { get; set; }

    public string Name { get; set; }

    public string QuantityPerUnit { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public bool Discontinued { get; set; }

    public ICollection<BookingDetails> BookingDetails { get; set; } = new HashSet<BookingDetails>();

}

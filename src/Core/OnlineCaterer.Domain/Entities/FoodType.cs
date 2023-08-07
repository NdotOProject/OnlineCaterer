
namespace OnlineCaterer.Domain.Entities;

public class FoodType : BaseEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public Caterer? Caterer { get; set; }

    public ICollection<Food> Foods { get; set; } = new HashSet<Food>();

}

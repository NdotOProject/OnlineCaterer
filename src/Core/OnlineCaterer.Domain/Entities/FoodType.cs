
using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Entities;

public class FoodType : BaseEntity
{
    //[Key]
    public int Id { get; set; }

    //[Required]
    //[StringLength(255)]
    public string? Name { get; set; }

    public string? Description { get; set; }// = "No Description";

    public ICollection<Caterer> Caterers { get; set; } = new HashSet<Caterer>();

    public ICollection<Food> Foods { get; set; } = new HashSet<Food>();

}

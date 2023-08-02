
using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Entities;

public class Caterer : BaseEntity
{
    [Key]
    public int UserId { get; set; }

    public string IntroduceMessage { get; set; } = string.Empty;

    public ICollection<ResponseMessage> ResponseMessages { get; set; } = new HashSet<ResponseMessage>();

    public ICollection<FoodType> FoodTypes { get; set; } = new HashSet<FoodType>();

    public ICollection<Place> Places { get; set; } = new HashSet<Place>();

}

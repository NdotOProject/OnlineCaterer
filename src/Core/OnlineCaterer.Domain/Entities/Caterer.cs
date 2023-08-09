
namespace OnlineCaterer.Domain.Entities;

public class Caterer : BaseUser
{
    public string IntroduceMessage { get; set; }

    public ICollection<ResponseMessage> ResponseMessages { get; set; } = new HashSet<ResponseMessage>();

    public ICollection<FoodType> FoodTypes { get; set; } = new HashSet<FoodType>();

    public ICollection<Place> Places { get; set; } = new HashSet<Place>();

}

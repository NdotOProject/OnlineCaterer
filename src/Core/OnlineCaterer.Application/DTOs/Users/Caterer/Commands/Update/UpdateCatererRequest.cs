
namespace OnlineCaterer.Application.DTOs.Users.Caterer.Commands.Update;

public class UpdateCatererRequest : IRequest<SimpleCatererResponse>
{
    // caterer
    public string UserId { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string IntroduceMessage { get; set; }

    /*
    public ICollection<ResponseMessageResponse> ResponseMessages { get; set; }
    public ICollection<SimpleFoodTypeResponse> FoodTypes { get; set; }
    public ICollection<PlaceResponse> Places { get; set; }
    */
}

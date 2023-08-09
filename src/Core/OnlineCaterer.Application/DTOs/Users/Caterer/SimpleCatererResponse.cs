
namespace OnlineCaterer.Application.DTOs.Users.Caterer;

public class SimpleCatererResponse : BasicUserResponse
{
    public string? IntroduceMessage { get; set; }

    public ICollection<ResponseMessageResponse>? ResponseMessages { get; set; }

    public ICollection<SimpleFoodTypeResponse>? FoodTypes { get; set; }

    public ICollection<PlaceResponse>? Places { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Caterer,SimpleCatererResponse>();
        }
    }
}

using OnlineCaterer.Domain.Entities;

namespace OnlineCaterer.Application.DTOs.User.Caterer;

public class SimpleCatererResponse : BasicUserResponse
{
    public string? IntroduceMessage { get; set; }

    public ICollection<ResponseMessage>? ResponseMessages { get; set; }

    public ICollection<FoodType>? FoodTypes { get; set; }

    public ICollection<Place>? Places { get; set; }

}

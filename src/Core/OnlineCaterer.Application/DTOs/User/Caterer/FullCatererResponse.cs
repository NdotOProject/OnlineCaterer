using OnlineCaterer.Domain.Entities;

namespace OnlineCaterer.Application.DTOs.User.Caterer;

public class FullCatererResponse
{
    public ShortCatererResponse? Basic { get; set; }

    public string? IntroduceMessage { get; set; }

    public ICollection<ResponseMessage>? ResponseMessages { get; set; }

    public ICollection<FoodType>? FoodTypes { get; set; }

    public ICollection<Place>? Places { get; set; }

    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }

}

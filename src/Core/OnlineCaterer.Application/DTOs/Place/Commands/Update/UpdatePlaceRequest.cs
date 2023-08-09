
namespace OnlineCaterer.Application.DTOs.Place.Commands.Update;

public record UpdatePlaceRequest : IRequest<PlaceResponse>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

}

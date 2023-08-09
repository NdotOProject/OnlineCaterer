
namespace OnlineCaterer.Application.DTOs.Place.Commands.Create;

public record CreatePlaceRequest : IRequest<PlaceResponse>
{
    public string Name { get; init; }

    public string Description { get; set; }

}

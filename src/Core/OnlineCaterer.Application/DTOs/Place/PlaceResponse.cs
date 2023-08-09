
namespace OnlineCaterer.Application.DTOs.Place;

public class PlaceResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Place, PlaceResponse>();
        }
    }
}


namespace OnlineCaterer.Application.DTOs.Place.Commands.Update;

public class UpdatePlaceRequestHandler : IRequestHandler<UpdatePlaceRequest, PlaceResponse>
{
    private readonly IRepository<Domain.Entities.Place> _placeRespository;
    private readonly IMapper _mapper;

    public UpdatePlaceRequestHandler(
        IRepository<Domain.Entities.Place> placeRespository,
        IMapper mapper)
    {
        _placeRespository = placeRespository;
        _mapper = mapper;
    }

    public async Task<PlaceResponse> Handle(UpdatePlaceRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.Entities.Place>(request);

        var updatedPlace = _placeRespository.Update(entity);

        await _placeRespository.SaveChangesAsync();

        return _mapper.Map<PlaceResponse>(updatedPlace);
    }
}

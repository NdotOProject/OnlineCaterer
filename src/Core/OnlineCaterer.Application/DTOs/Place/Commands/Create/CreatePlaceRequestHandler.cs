
namespace OnlineCaterer.Application.DTOs.Place.Commands.Create;

public class CreatePlaceRequestHandler : IRequestHandler<CreatePlaceRequest, PlaceResponse>
{
    private readonly IRepository<Domain.Entities.Place> _placeRespository;
    private readonly IMapper _mapper;

    public CreatePlaceRequestHandler(
        IRepository<Domain.Entities.Place> placeRespository,
        IMapper mapper)
    {
        _placeRespository = placeRespository;
        _mapper = mapper;
    }

    public async Task<PlaceResponse> Handle(CreatePlaceRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.Entities.Place>(request);

        var insertedPlace = _placeRespository.Insert(entity);

        await _placeRespository.SaveChangesAsync();

        return _mapper.Map<PlaceResponse>(insertedPlace);
    }
}

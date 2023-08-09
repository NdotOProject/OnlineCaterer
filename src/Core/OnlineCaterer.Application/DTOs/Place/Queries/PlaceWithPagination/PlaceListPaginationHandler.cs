
namespace OnlineCaterer.Application.DTOs.Place.Queries.PlaceWithPagination;

public class PlaceListPaginationHandler : IRequestHandler<PlaceListPaginationModel, PaginatedList<PlaceResponse>>
{
    private readonly IRepository<Domain.Entities.Place> _placeRespository;
    private readonly IMapper _mapper;

    public PlaceListPaginationHandler(
        IRepository<Domain.Entities.Place> placeRespository,
        IMapper mapper)
    {
        _placeRespository = placeRespository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PlaceResponse>> Handle(PlaceListPaginationModel request, CancellationToken cancellationToken)
    {
        return await _placeRespository.GetQueryable()
            .OrderBy(p => p.Name)
            .ProjectTo<PlaceResponse>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

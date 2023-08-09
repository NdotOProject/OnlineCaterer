
namespace OnlineCaterer.Application.DTOs.Place.Queries.PlaceWithPagination;

public class PlaceListPaginationModel : IRequest<PaginatedList<PlaceResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

}

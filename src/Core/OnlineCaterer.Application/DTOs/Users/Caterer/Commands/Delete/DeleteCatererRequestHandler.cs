
namespace OnlineCaterer.Application.DTOs.Users.Caterer.Commands.Delete;

public class DeleteCatererRequestHandler : IRequestHandler<DeleteCatererRequest, SimpleCatererResponse>
{
    private readonly IRepository<Domain.Entities.Caterer> _catererRepository;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public DeleteCatererRequestHandler(
        IMapper mapper,
        IIdentityService identityService,
        IRepository<Domain.Entities.Caterer> catererRepository)
    {
        _mapper = mapper;
        _identityService = identityService;
        _catererRepository = catererRepository;
    }

    public Task<SimpleCatererResponse> Handle(DeleteCatererRequest request, CancellationToken cancellationToken)
    {
        /*if (request != null)
        {
            var deleteSuccess = await _identityService.DeleteUserAsync(request.UserId);

            var caterer = await _catererRepository.GetByIdAsync(request.UserId);


        }*/

        throw new NotImplementedException();
    }
}

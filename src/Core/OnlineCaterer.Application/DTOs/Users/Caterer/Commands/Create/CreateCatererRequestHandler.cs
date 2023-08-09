
namespace OnlineCaterer.Application.DTOs.Users.Caterer.Commands.Create;

public class CreateCatererRequestHandler : IRequestHandler<CreateCatererRequest, SimpleCatererResponse>
{
    private readonly IRepository<Domain.Entities.Caterer> _catererRepository;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public CreateCatererRequestHandler(
        IRepository<Domain.Entities.Caterer> catererRepository,
        IIdentityService identityService,
        IMapper mapper)
    {
        _catererRepository = catererRepository;
        _identityService = identityService;
        _mapper = mapper;
    }

    public async Task<SimpleCatererResponse> Handle(CreateCatererRequest request, CancellationToken cancellationToken)
    {
        if (request is not null)
        {
            if (request.UserName != null && request.Email != null && request.Password != null)
            {

                var user = await _identityService.CreateUserAsync(
                    userName: request.UserName,
                    email: request.Email,
                    password: request.Password
                );

                string userId = user.UserId;

                var entity = _mapper.Map<Domain.Entities.Caterer>(request);
                entity.UserId = userId;

                _catererRepository.Insert(entity);

                await _catererRepository.SaveChangesAsync();

                return new SimpleCatererResponse
                {
                    Id = entity.UserId,
                    Name = entity.Name,
                    Address = entity.Address,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    UserName = request.UserName,
                    Password = request.Password,
                };
            }
        }

        throw new NullReferenceException();
    }
}

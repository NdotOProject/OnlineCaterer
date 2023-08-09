
namespace OnlineCaterer.Application.DTOs.Users.Caterer.Commands.Delete;

public class DeleteCatererRequest : IRequest<SimpleCatererResponse>
{
    public string UserId { get; set; }
}

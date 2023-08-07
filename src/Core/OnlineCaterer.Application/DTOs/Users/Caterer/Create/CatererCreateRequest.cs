
namespace OnlineCaterer.Application.DTOs.Users.Caterer;

public class CatererCreateRequest : IRequest<int>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public string? UserName { get; set; }
    public string? Password { get; set; }
}

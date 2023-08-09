
namespace OnlineCaterer.Application.Initialization;

public class User
{
    public List<string> Roles { get; set; }

    public string Email { get; set; }
    public string? PhoneNumber { get; set; } = null;

    public string UserName { get; set; }
    public string Password { get; set; }

    public Caterer? CatererInfo { get; set; } = null;

    public Customer? CustomerInfo { get; set; } = null;
}

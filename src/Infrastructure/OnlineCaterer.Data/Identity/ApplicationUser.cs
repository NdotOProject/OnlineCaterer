
namespace OnlineCaterer.Data.Identity;

public class ApplicationUser : IdentityUser
{
    public override string ToString()
    {
        string str = $"User[Id={Id}, UserName={UserName}, Email={Email}, PhoneNumber={PhoneNumber}, PasswordHash={PasswordHash}]";

        return str;
    }
}

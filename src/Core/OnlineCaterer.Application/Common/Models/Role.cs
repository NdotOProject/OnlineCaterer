
namespace OnlineCaterer.Application.Common.Models;

public class Role
{
    public string? Name { get; set; }
    public string? User { get; set; }

    public override string ToString()
    {
        return $"\"Name\": \"{Name}\", \"User\": \"{User}\"";
    }
}

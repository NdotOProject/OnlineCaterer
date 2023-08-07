
using System.ComponentModel.DataAnnotations;

namespace OnlineCaterer.Data.Identity;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string? Name { get; set; }

    public string? Address { get; set; }

}

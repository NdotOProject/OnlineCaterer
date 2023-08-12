using System.ComponentModel.DataAnnotations;

namespace OnlineCaterer.Web.Models.Users;

public class CatererRegisterViewModel
{
    // Caterer Fields
    [Required]
    [Display(Name = "Company Name")]
    [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Address")]
    [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
    public string Address { get; set; }

    // ApplicationUser Fields
    [Required]
    [Display(Name = "Email")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Display(Name = "Password")]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    //public string ReturnUrl { get; set; }
}

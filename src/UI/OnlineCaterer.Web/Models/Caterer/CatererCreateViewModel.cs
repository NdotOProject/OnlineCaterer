using System.ComponentModel.DataAnnotations;

namespace OnlineCaterer.Web.Models.Caterer
{
	public class CatererCreateViewModel
	{
		// Caterer Fields
		[Display(Name = "Company Name")]
		[Required]
		[StringLength(500, MinimumLength = 1, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
		public string Name { get; set; }

		[Display(Name = "Address")]
		[Required]
		[StringLength(500, MinimumLength = 5, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
		public string Address { get; set; }

		// ApplicationUser Fields
		[Display(Name = "Email")]
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Display(Name = "Password")]
		[Required]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}
}

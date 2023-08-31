using System.ComponentModel.DataAnnotations;

namespace OnlineCaterer.Web.Models.FoodType
{
	public class FoodTypeCreateViewModel
	{
		[Display(Name = "Category Name")]
		[Required]
		[StringLength(100, MinimumLength = 1,
				ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
		public string Name { get; set; }

		[Display(Name = "Category Description")]
		public string? Description { get; set; }

	}
}

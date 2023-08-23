
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace OnlineCaterer.Web.Views.FoodType
{
    [Authorize(Roles = ConstantsRoles.Caterer)]
    public class CreateFoodTypeModel : PageModel
    {
        private readonly IRepository<Domain.Entities.FoodType> _foodTypeRepository;
        private readonly IUser _user;

        public CreateFoodTypeModel(
            IRepository<Domain.Entities.FoodType> foodTypeRepository,
            IUser user)
        {
            _foodTypeRepository = foodTypeRepository;
            _user = user;
        }

        public class CreateFoodTypeViewModel
        {
            [Display(Name = "Category Name")]
            [Required]
            [StringLength(100, MinimumLength = 1,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            public string Name { get; set; }

            [Display(Name = "Category Description")]
            public string? Description { get; set; }

        }

        [BindProperty]
        public CreateFoodTypeViewModel Input { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                string? catererId = _user.Id;
                if (catererId != null)
                {
                    _foodTypeRepository.Insert(new Domain.Entities.FoodType
                    {
                        Name = Input.Name,
                        Description = Input.Description ?? "No Description",
                        CatererId = catererId,
                    });

                    await _foodTypeRepository.SaveChangesAsync();

                    return RedirectToPage("./FoodTypeIndex");
                }
            }
            return Page();
        }
    }
}

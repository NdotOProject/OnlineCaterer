
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Domain.Constants;
using OnlineCaterer.Web.Models.FoodType;

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

        [BindProperty]
        public FoodTypeCreateViewModel Input { get; set; }

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
					return RedirectToPage(ViewPathManager.FoodTypeIndex);
                }
            }
            return Page();
        }
    }
}

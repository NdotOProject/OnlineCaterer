using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Domain.Constants;
using OnlineCaterer.Web.Models.Food;

namespace OnlineCaterer.Web.Views.Auth.Caterer.Food
{
    [Authorize(Roles = ConstantsRoles.Caterer)]
    public class CreateFoodModel : PageModel
    {
        private readonly IRepository<Domain.Entities.Food> _foodRepository;
        private readonly IUser _user;

        public CreateFoodModel(
			IRepository<Domain.Entities.Food> foodRepository,
			IUser user)
        {
            _foodRepository = foodRepository;
            _user = user;
        }

        [BindProperty]
        public FoodCreateViewModel Input { get; set; }

		public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(
            [FromRoute(Name = "categoryId")] int categoryId)
        {
            if (ModelState.IsValid)
            {
                string? catererId = _user.Id;
                if (catererId != null)
                {
                    var food = new Domain.Entities.Food
                    {
                        CategoryId = categoryId,
                        Name = Input.Name,
                        QuantityPerUnit = Input.QuantityPerUnit,
                        Description = Input.Description,
                        Price = Input.Price,
                    };
                    _foodRepository.Insert(food);
                    await _foodRepository.SaveChangesAsync();
					return RedirectToPage(ViewPathManager.FoodIndex);
                }
            }
            return Page();
        }
    }
}

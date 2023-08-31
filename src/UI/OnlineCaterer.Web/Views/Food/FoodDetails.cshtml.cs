using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Web.Models.Food;

namespace OnlineCaterer.Web.Views.Food
{
    public class FoodDetailsModel : PageModel
    {
        private readonly IRepository<Domain.Entities.Food> _foodRepository;
        private readonly IRepository<Domain.Entities.FoodType> _foodTypeRepository;

		public FoodDetailsModel(
            IRepository<Domain.Entities.Food> foodRepository,
			IRepository<Domain.Entities.FoodType> foodTypeRepository)
        {
            _foodRepository = foodRepository;
            _foodTypeRepository = foodTypeRepository;
        }

        public FoodDetailsViewModel FoodDetails { get; set; }

        public string ReturnUrl { get; private set; }

        public async Task OnGetAsync(
            [FromRoute(Name = "foodId")] int foodId,
            string returnUrl)
        {
            ReturnUrl = returnUrl;

            FoodDetails = await _foodRepository
                .GetQueryable()
                .Where(f => f.FoodId == foodId)
                .ProjectTo<FoodDetailsViewModel>(
                    FoodDetailsViewModel.Mapper.Configuration
                ).FirstAsync();

			FoodDetails.Caterers = await _foodTypeRepository
                .GetQueryable()
                .Where(ft => ft.Id.Equals(FoodDetails.CategoryId))
                .Select(ft => ft.Caterer.Name)
                .FirstAsync();
        }
    }
}

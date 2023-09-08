using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Web.Models.Caterer;
using OnlineCaterer.Web.Models.Food;
using OnlineCaterer.Web.Models.FoodType;

namespace OnlineCaterer.Web.Views.Home
{
    public class IndexModel : PageModel
    {

        private readonly IRepository<Domain.Entities.FoodType> _foodTypeRepository;
        private readonly IRepository<Domain.Entities.Food> _foodRespoitory;
        private readonly IRepository<Domain.Entities.Caterer> _catererRepository;

        public IndexModel(
            IRepository<Domain.Entities.FoodType> foodTypeRepository,
            IRepository<Domain.Entities.Food> foodRespoitory,
            IRepository<Domain.Entities.Caterer> catererRepository)
        {
            _foodTypeRepository = foodTypeRepository;
            _foodRespoitory = foodRespoitory;
            _catererRepository = catererRepository;
        }

        public List<FoodTypeIndexViewModel> FoodTypes { get; set; }

        public List<FoodIndexViewModel> Foods { get; set; }

		public List<CatererIndexViewModel> Caterers { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            FoodTypes = await _foodTypeRepository
                .GetQueryable()
                .OrderBy(ft => ft.Name)
                .Take(4)
                .ProjectToListAsync<FoodTypeIndexViewModel>(
                    FoodTypeIndexViewModel.Mapper.Configuration
                );

            var foodTypeIds = FoodTypes
                .Select(ft => ft.Id)
                .ToList();

            Foods = await _foodRespoitory
                .GetQueryable()
                .Where(f => foodTypeIds.Contains(f.CategoryId))
                .Take(9)
                .OrderBy(f => f.Name)
                .ProjectToListAsync<FoodIndexViewModel>(
                    FoodIndexViewModel.Mapper.Configuration
                ); 

			Caterers = await _catererRepository
                .GetQueryable()
				.OrderBy(c => c.Name)
				.Take(5)
				.ProjectToListAsync<CatererIndexViewModel>(
					CatererIndexViewModel.Mapper.Configuration
				);
            return Page();
		}
    }
}

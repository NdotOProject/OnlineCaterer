using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Constants;
using OnlineCaterer.Web.Models.Food;

namespace OnlineCaterer.Web.Views.Food
{
    public class FoodIndexModel : PageModel
    {
		private const int PAGE_SIZE = 9;

		private readonly IRepository<Domain.Entities.Food> _foodRepository;

		public FoodIndexModel(
            IRepository<Domain.Entities.Food> foodRepository)
		{
			_foodRepository = foodRepository;
		}

        public PaginatedList<FoodIndexViewModel> Foods { get; set; }

		[BindProperty(SupportsGet = true, Name = PaginationQuery.Name)]
		public int? CurrentPage { get; set; }

		public async Task OnGetAsync(
            [FromRoute(Name = "categoryId")] int? categoryId,
            string? name)
        {
			var queryable = _foodRepository.GetQueryable();
            if (categoryId != null)
            {
                queryable = queryable.Where(f => f.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(name))
            {
                queryable = queryable.Where(f => f.Name.Contains(name));
            }

            Foods = await queryable.OrderBy(f => f.Name)
                .ProjectTo<FoodIndexViewModel>(FoodIndexViewModel.Mapper.Configuration)
                .PaginatedListAsync(pageNumber: CurrentPage ?? 1 , pageSize: PAGE_SIZE);

        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Constants;

namespace OnlineCaterer.Web.Views.Food
{
    public class FoodIndexModel : PageModel
    {
		private const int PAGE_SIZE = 1;
        private readonly MapperConfiguration foodMapperConfiguration = new(config =>
            config.CreateProjection<Domain.Entities.Food, FoodIndexViewModel>()
            .ForMember(vm => vm.FoodId, conf => conf.MapFrom(f => f.FoodId))
			.ForMember(vm => vm.CategoryId, conf => conf.MapFrom(f => f.CategoryId))
			.ForMember(vm => vm.Category, conf => conf.MapFrom(f => f.Category.Name))
			.ForMember(vm => vm.Name, conf => conf.MapFrom(f => f.Name))
			.ForMember(vm => vm.Price, conf => conf.MapFrom(f => f.Price))
			.ForMember(vm => vm.Discontinued, conf => conf.MapFrom(f => f.Discontinued))
		);

		private readonly IRepository<Domain.Entities.Food> _foodRepository;

		public FoodIndexModel(
            IRepository<Domain.Entities.Food> foodRepository)
		{
			_foodRepository = foodRepository;
		}

		public class FoodIndexViewModel
        {
            public int FoodId { get; set; }
            public int CategoryId { get; set; }
            public string Category { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public bool Discontinued { get; set; }
        }

		public PaginatedList<FoodIndexViewModel> Foods { get; set; }

		[BindProperty(SupportsGet = true, Name = PaginationQuery.Name)]
		public int? CurrentPage { get; set; }

		public async Task OnGetAsync([FromRoute(Name = "categoryId")] int? categoryId, string? name)
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
                .ProjectTo<FoodIndexViewModel>(foodMapperConfiguration)
                .PaginatedListAsync(pageNumber: CurrentPage ?? 1 , pageSize: PAGE_SIZE);

        }
    }
}

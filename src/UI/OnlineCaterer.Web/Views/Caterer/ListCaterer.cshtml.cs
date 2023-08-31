using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Constants;
using OnlineCaterer.Web.Models.Caterer;

namespace OnlineCaterer.Web.Views.Caterer
{
	public class CatererIndexModel : PageModel
    {
		private const int PAGE_SIZE = 9;

        private readonly IRepository<Domain.Entities.Caterer> _catererRepository;

		public CatererIndexModel(
			IRepository<Domain.Entities.Caterer> catererRepository)
		{
			_catererRepository = catererRepository;
		}

		public PaginatedList<CatererIndexViewModel> Caterers { get; set; }

		[BindProperty(SupportsGet = true, Name = PaginationQuery.Name)]
		public int? CurrentPage { get; set; }

		public async Task OnGetAsync(string name)
        {
			var queryable = _catererRepository.GetQueryable();

			if (!string.IsNullOrWhiteSpace(name))
			{
				queryable = queryable.Where(c =>
					c.Name != null && c.Name.Contains(name)
				);
			}

			Caterers = await queryable
				.OrderBy(c => c.Name)
				.ProjectTo<CatererIndexViewModel>(
					CatererIndexViewModel.Mapper.Configuration
				).PaginatedListAsync(
					pageNumber: CurrentPage ?? 1,
					pageSize: PAGE_SIZE
				);
        }
    }
}

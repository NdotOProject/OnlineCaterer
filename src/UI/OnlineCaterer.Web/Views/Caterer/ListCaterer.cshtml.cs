using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Constants;

namespace OnlineCaterer.Web.Views.Caterer
{
	public class CatererIndexModel : PageModel
    {
		private const int PAGE_SIZE = 4;
        public static readonly MapperConfiguration CatererIndexConfiguration = new(config =>
            config.CreateProjection<Domain.Entities.Caterer, CatererIndexViewModel>()
            .ForMember(vm => vm.UserId, conf => conf.MapFrom(c => c.UserId))
            .ForMember(vm => vm.Name, conf => conf.MapFrom(c => c.Name))
            .ForMember(vm => vm.Address, conf => conf.MapFrom(c => c.Address))
            .ForMember(vm => vm.IntroduceMessage, conf => conf.MapFrom(c => c.IntroduceMessage))
			.ForMember(vm => vm.Places, conf => conf.MapFrom(c => c.Places.Select(c => c.Name).ToList()))
		);

        private readonly IRepository<Domain.Entities.Caterer> _catererRepository;

		public CatererIndexModel(
			IRepository<Domain.Entities.Caterer> catererRepository)
		{
			_catererRepository = catererRepository;
		}

		public class CatererIndexViewModel
        {
			public string UserId { get; set; }
			public string Name { get; set; }
			public string Address { get; set; }
			public string IntroduceMessage { get; set; }
			public List<string> Places { get; set; }

		}

        public PaginatedList<CatererIndexViewModel> Caterers { get; set; }

		[BindProperty(SupportsGet = true, Name = PaginationQuery.Name)]
		public int? CurrentPage { get; set; }

		public async Task OnGetAsync(string name)
        {
			var queryable = _catererRepository.GetQueryable();
			if (!string.IsNullOrEmpty(name))
			{
				queryable = queryable.Where(c => c.Name != null && c.Name.Contains(name));
			}

			Caterers = await queryable.OrderBy(c => c.Name)
				.ProjectTo<CatererIndexViewModel>(CatererIndexConfiguration)
				.PaginatedListAsync(pageNumber: CurrentPage ?? 1, pageSize: PAGE_SIZE);

        }
    }
}

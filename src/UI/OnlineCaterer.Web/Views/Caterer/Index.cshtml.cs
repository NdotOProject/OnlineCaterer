using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Web.Models;

namespace OnlineCaterer.Web.Views.Caterer
{
    public class IndexModel : PageModel
    {
		private const int PAGE_SIZE = 6;

        private readonly IRepository<Domain.Entities.Caterer> _catererRepository;

		public IndexModel(
			IRepository<Domain.Entities.Caterer> catererRepository)
		{
			_catererRepository = catererRepository;
		}

		public class CatererIndexViewModel : IViewModel
        {
			public string UserId { get; set; }
			public string Name { get; set; }
			public string Address { get; set; }
			public string IntroduceMessage { get; set; }

		}

        public PaginatedList<CatererIndexViewModel> Caterers { get; set; }

		[BindProperty(SupportsGet = true, Name = "p")]
		public int? CurrentPage { get; set; }

		private readonly MapperConfiguration Configuration = new MapperConfiguration(config =>
				config.CreateProjection<Domain.Entities.Caterer, CatererIndexViewModel>()
				.ForMember(vm => vm.UserId, conf => conf.MapFrom(c => c.UserId))
				.ForMember(vm => vm.Name, conf => conf.MapFrom(c => c.Name))
				.ForMember(vm => vm.Address, conf => conf.MapFrom(c => c.Address))
				.ForMember(vm => vm.IntroduceMessage, conf => conf.MapFrom(c => c.IntroduceMessage))
			);

		public async Task OnGetAsync(string name)
        {

			if (!string.IsNullOrEmpty(name))
			{
				Caterers = await _catererRepository.GetQueryable()
					.Where(c => c.Name != null && c.Name.Contains(name))
					.ProjectTo<CatererIndexViewModel>(Configuration)
					.PaginatedListAsync(pageNumber: CurrentPage ?? 1, pageSize: PAGE_SIZE);
			}
			else
			{
				Caterers = await _catererRepository.GetQueryable()
					.ProjectTo<CatererIndexViewModel>(Configuration)
					.PaginatedListAsync(pageNumber: CurrentPage ?? 1, pageSize: PAGE_SIZE);
			}
		}
    }
}

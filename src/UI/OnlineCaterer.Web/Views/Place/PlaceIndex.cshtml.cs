using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Common.Interfaces.Data;

namespace OnlineCaterer.Web.Views.Place
{
    public class IndexModel : PageModel
    {
        private readonly MapperConfiguration mapperConfiguration = new(config =>
            config.CreateProjection<Domain.Entities.Place, PlaceIndexViewModel>()
            .ForMember(vm => vm.Id, conf => conf.MapFrom(p => p.Id))
            .ForMember(vm => vm.Name, conf => conf.MapFrom(p => p.Name))
        );

        private readonly IRepository<Domain.Entities.Place> _placeRepository;

        public IndexModel(IRepository<Domain.Entities.Place> placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public class PlaceIndexViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public List<PlaceIndexViewModel> Places { get; set; }

        public async Task OnGetAsync(string name)
        {
            var queryable = _placeRepository.GetQueryable();
			if (name != null)
			{
			   queryable.Where(p => p.Name.Contains(name));
			}

            Places = await queryable.OrderBy(p => p.Name)
                .ProjectTo<PlaceIndexViewModel>(mapperConfiguration)
                .ToListAsync();
        }
    }
}

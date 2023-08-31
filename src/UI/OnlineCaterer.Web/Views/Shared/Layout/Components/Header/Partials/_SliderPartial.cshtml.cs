using AutoMapper.QueryableExtensions;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Web.Models.Caterer;

namespace OnlineCaterer.Web.Views.Shared.Layout.Components.Header.Partials
{
	public class SliderPartial
	{
		public List<CatererIndexViewModel> Caterers { get; private set; }

		public SliderPartial(IRepository<Domain.Entities.Caterer> catererRepository)
		{
			Caterers = catererRepository.GetQueryable()
				.OrderBy(c => c.Name)
				.Take(3)
				.ProjectTo<CatererIndexViewModel>(
					CatererIndexViewModel.Mapper.Configuration
				).ToList();
		}
	}
}

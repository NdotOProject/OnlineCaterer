using AutoMapper.QueryableExtensions;
using OnlineCaterer.Application.Common.Interfaces.Data;
using static OnlineCaterer.Web.Views.Caterer.CatererIndexModel;

namespace OnlineCaterer.Web.Views.Shared.Layout.Components.Header.Partials
{
	public class SliderPartial
	{
		public List<CatererIndexViewModel> Caterers { get; private set; }

		public SliderPartial(IRepository<Domain.Entities.Caterer> catererRepository)
		{
			Caterers = catererRepository.GetQueryable()
				.OrderBy(c => c.Name)
				.ProjectTo<CatererIndexViewModel>(CatererIndexConfiguration)
				.Take(3)
				.ToList();
		}
	}
}

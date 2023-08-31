using AutoMapper;

namespace OnlineCaterer.Web.Models.Caterer
{
	public class CatererIndexViewModel
	{
		public string UserId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string IntroduceMessage { get; set; }
		public List<string> Places { get; set; }

		public class Mapper
		{
			public static readonly MapperConfiguration Configuration = new(config =>
			config.CreateProjection<Domain.Entities.Caterer, CatererIndexViewModel>()
			.ForMember(vm => vm.Places, conf => conf.MapFrom(c => c.Places.Select(c => c.Name).ToList()))
		);
		}
	}
}

using AutoMapper;

namespace OnlineCaterer.Web.Models.Food
{
	public class FoodIndexViewModel
	{
		public int FoodId { get; set; }
		public int CategoryId { get; set; }
		public string Category { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }

		public class Mapper
		{
			public static readonly MapperConfiguration Configuration = new(config =>
			config.CreateProjection<Domain.Entities.Food, FoodIndexViewModel>()
			.ForMember(vm => vm.Category, conf => conf.MapFrom(f => f.Category.Name))
		);
		}
	}
}

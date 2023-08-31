using AutoMapper;

namespace OnlineCaterer.Web.Models.Food
{
	public class FoodDetailsViewModel : FoodIndexViewModel
	{
		public string QuantityPerUnit { get; set; }

		public string Description { get; set; }

		public string? Caterers { get; set; }

		public new class Mapper
		{
			public static readonly MapperConfiguration Configuration = new(config =>
				config.CreateProjection<Domain.Entities.Food, FoodDetailsViewModel>()
				.ForMember(vm => vm.Category, conf => conf.MapFrom(f => f.Category.Name))
			);
		}
	}
}

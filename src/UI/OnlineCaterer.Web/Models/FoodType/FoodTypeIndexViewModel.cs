using AutoMapper;

namespace OnlineCaterer.Web.Models.FoodType
{
	public class FoodTypeIndexViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public class Mapper
		{
			public static readonly MapperConfiguration Configuration = new(config =>
				config.CreateProjection<Domain.Entities.FoodType, FoodTypeIndexViewModel>()
			);
		}
	}
}

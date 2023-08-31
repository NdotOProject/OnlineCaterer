using AutoMapper;

namespace OnlineCaterer.Web.Models.BookingDetails
{
	public class BookingDetailsIndexViewModel
	{
		public Domain.Entities.Food Food { get; set; }

		public decimal UnitPrice { get; set; }

		public int Quantity { get; set; }

		public float Discount { get; set; }

		public class Mapper
		{
			public static readonly MapperConfiguration Configuration = new(config => 
				config.CreateProjection<Domain.Entities.BookingDetails, BookingDetailsIndexViewModel>()
			);
		}

	}

}

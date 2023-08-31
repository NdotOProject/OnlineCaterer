using AutoMapper;

namespace OnlineCaterer.Web.Models.Booking
{
	public class BookingIndexViewModel
	{
		public int BookingId { get; set; }

		public string OrderBy { get; set; }

		public string SupplyBy { get; set; }

		public decimal TotalAmount { get; set; }

		public DateTime EventDate { get; set; }

		public DateTime BookingDate { get; set; }

		public class Mapper
		{
			public static readonly MapperConfiguration Configuration = new(config => 
				config.CreateProjection<Domain.Entities.Booking, BookingIndexViewModel>()
				.ForMember(vm => vm.OrderBy, conf => conf.MapFrom(b => b.Customer.Name))
				.ForMember(vm => vm.SupplyBy, conf => conf.MapFrom(b => b.Caterer.Name))
			);
		}
	}
}

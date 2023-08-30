using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Constants;

namespace OnlineCaterer.Web.Views.Auth.Booking
{
	[Authorize]
	public class BookingIndexModel : PageModel
	{
        private const int PAGE_SIZE = 10;

		public static readonly MapperConfiguration bookingMapperConfiguration = new(config =>
			config.CreateProjection<Domain.Entities.Booking, BookingIndexViewModel>()
			.ForMember(vm => vm.BookingId, conf => conf.MapFrom(b => b.BookingId))
            .ForMember(vm => vm.TotalAmount, conf => conf.MapFrom(b => b.TotalAmount))
            .ForMember(vm => vm.EventDate, conf => conf.MapFrom(b => b.EventDate))
            .ForMember(vm => vm.BookingDate, conf => conf.MapFrom(b => b.BookingDate))
            .ForMember(vm => vm.OrderBy, conf => conf.MapFrom(b => b.Customer.Name))
            .ForMember(vm => vm.SupplyBy, conf => conf.MapFrom(b => b.Caterer.Name))
		);

        private readonly IRepository<Domain.Entities.Booking> _bookingRepository;
		private readonly IUser _user;

		public BookingIndexModel(
            IRepository<Domain.Entities.Booking> bookingRepository,
            IUser user)
		{
			_bookingRepository = bookingRepository;
			_user = user;
		}

		public class BookingIndexViewModel
		{
            public int BookingId { get; set; }

			public string OrderBy { get; set; }

			public string SupplyBy { get; set; }

			public decimal TotalAmount { get; set; }

            public DateTime EventDate { get; set; }

			public DateTime BookingDate { get; set; }
        }

        [BindProperty(SupportsGet = true, Name = PaginationQuery.Name)]
        public int? CurrentPage { get; set; }

        public PaginatedList<BookingIndexViewModel> BookingList { get; set; }

        public async Task OnGetAsync()
		{
			BookingList = await _bookingRepository.GetQueryable()
				.Where(b =>
					b.CustomerId.Equals(_user.Id) || b.CatererId.Equals(_user.Id)
				)
				.OrderBy(b => b.EventDate)
				.ProjectTo<BookingIndexViewModel>(bookingMapperConfiguration)
				.PaginatedListAsync(pageNumber: CurrentPage ?? 1, pageSize: PAGE_SIZE);
		}

	}
}



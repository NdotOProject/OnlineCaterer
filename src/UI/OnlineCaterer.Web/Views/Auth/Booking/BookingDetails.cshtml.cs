using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Entities;

namespace OnlineCaterer.Web.Views.Auth.Booking
{
	[Authorize]
    public class BookingDetailsModel : PageModel
    {
        private readonly int PAGE_SIZE = 10;

        private readonly MapperConfiguration bookingDetailsMapperConfig = new(config =>
            config.CreateProjection<BookingDetails, BookingDetailsViewModel>()
            /*.ForMember(vm => vm.Food, conf => conf.MapFrom(bd => bd.Food))
			.ForMember(vm => vm.UnitPrice, conf => conf.MapFrom(bd => bd.UnitPrice))
            .ForMember(vm => vm.Quantity, conf => conf.MapFrom(bd => bd.Quantity))
            .ForMember(vm => vm.Discount, conf => conf.MapFrom(bd => bd.Discount))*/
        );

        private readonly IRepository<BookingDetails> _bookingDetailsRepository;

		public BookingDetailsModel(IRepository<BookingDetails> bookingDetailsRepository)
		{
			_bookingDetailsRepository = bookingDetailsRepository;
		}

		public class BookingDetailsViewModel
		{
			public Domain.Entities.Food Food { get; set; }
			
			public decimal UnitPrice { get; set; }

            public int Quantity { get; set; }

            public float Discount { get; set; }
        }

		public BookingIndexModel.BookingIndexViewModel BookingInfo { get; set; }
		
        public PaginatedList<BookingDetailsViewModel> Details { get; set; }

		public async Task OnGetAsync(
            [FromRoute(Name = "bookingId")] int bookingId)
        {
			var queryable = _bookingDetailsRepository.GetQueryable()
				.Where(bd => bd.BookingId == bookingId);

			BookingInfo = await queryable.Select(bd => bd.Booking)
				.ProjectTo<BookingIndexModel.BookingIndexViewModel>(
					BookingIndexModel.bookingMapperConfiguration
				)
				.FirstAsync();

			Details = await queryable
                .ProjectTo<BookingDetailsViewModel>(bookingDetailsMapperConfig)
				.PaginatedListAsync(pageNumber: 1, pageSize: PAGE_SIZE);

		}
	}
}

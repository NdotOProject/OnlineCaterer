using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Entities;
using OnlineCaterer.Web.Models.Booking;
using OnlineCaterer.Web.Models.BookingDetails;

namespace OnlineCaterer.Web.Views.Auth.Booking
{
	[Authorize]
    public class BookingDetailsModel : PageModel
    {
        private readonly int PAGE_SIZE = 10;

        private readonly IRepository<BookingDetails> _bookingDetailsRepository;
		public BookingDetailsModel(IRepository<BookingDetails> bookingDetailsRepository)
		{
			_bookingDetailsRepository = bookingDetailsRepository;
		}

		public BookingIndexViewModel BookingInfo { get; set; }
		
		public PaginatedList<BookingDetailsIndexViewModel> Details { get; set; }

		public async Task OnGetAsync(
			[FromRoute(Name = "bookingId")] int bookingId)
		{
			var queryable = _bookingDetailsRepository
				.GetQueryable()
				.Where(bd => bd.BookingId == bookingId);

			BookingInfo = await queryable.Select(bd => bd.Booking)
				.ProjectTo<BookingIndexViewModel>(
					BookingIndexViewModel.Mapper.Configuration
				).FirstAsync();

			Details = await queryable
				.ProjectTo<BookingDetailsIndexViewModel>(
					BookingDetailsIndexViewModel.Mapper.Configuration
				).PaginatedListAsync(pageNumber: 1, pageSize: PAGE_SIZE);
		}
	}
}

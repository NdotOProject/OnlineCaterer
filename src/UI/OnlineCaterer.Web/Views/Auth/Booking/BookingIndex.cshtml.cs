using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Constants;
using OnlineCaterer.Web.Models.Booking;

namespace OnlineCaterer.Web.Views.Auth.Booking
{
	[Authorize]
	public class BookingIndexModel : PageModel
	{
        private const int PAGE_SIZE = 10;

        private readonly IRepository<Domain.Entities.Booking> _bookingRepository;
		private readonly IUser _user;

		public BookingIndexModel(
            IRepository<Domain.Entities.Booking> bookingRepository,
            IUser user)
		{
			_bookingRepository = bookingRepository;
			_user = user;
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
				.ProjectTo<BookingIndexViewModel>(BookingIndexViewModel.Mapper.Configuration)
				.PaginatedListAsync(pageNumber: CurrentPage ?? 1, pageSize: PAGE_SIZE);
		}

	}
}



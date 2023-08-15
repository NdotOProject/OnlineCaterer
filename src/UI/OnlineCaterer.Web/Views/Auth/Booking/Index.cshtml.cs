using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;

namespace OnlineCaterer.Web.Views.Auth.Booking
{
	[Authorize]
	public class BookingIndexModel : PageModel
	{
		private readonly IRepository<Domain.Entities.Booking> _bookingRepository;
		private readonly IUser _user;



		public async Task<IActionResult> OnGetAsync()
		{
			return Page();
		}




	}
}



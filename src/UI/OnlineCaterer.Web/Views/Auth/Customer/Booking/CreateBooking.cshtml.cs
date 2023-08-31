using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Domain.Constants;
using OnlineCaterer.Web.Models.Booking;

namespace OnlineCaterer.Web.Views.Auth.Booking
{
    [Authorize(Roles = ConstantsRoles.Customer)]
    public class CreateBookingModel : PageModel
    {
        private readonly IRepository<Domain.Entities.Booking> _bookingRepository;
        private readonly IUser _user;

        public CreateBookingModel(
            IRepository<Domain.Entities.Booking> bookingRepository,
            IUser user)
        {
            _bookingRepository = bookingRepository;
            _user = user;
        }

        public BookingCreateViewModel Input { get; set; }

        public List<string> Categories { get; set; }

        [BindProperty(SupportsGet = true, Name = "catererId")]
        public string? CatererId { get; set; }

		public IActionResult OnGet()
        {

            return Page();
        }

        public void OnPost()
        {
        }

    }
}

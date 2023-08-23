using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Domain.Constants;

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

        public class CreateBookingViewModel
        {
            public string CatererId { get; set; }

            public DateTime EventDate { get; set; }

            public DateTime BookingDate { get; set; }

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public void OnPost()
        {

        }

    }
}

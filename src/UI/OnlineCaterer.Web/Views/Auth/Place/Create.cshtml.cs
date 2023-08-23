using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineCaterer.Web.Views.Place
{
    [Authorize]
    public class CreatePlaceModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

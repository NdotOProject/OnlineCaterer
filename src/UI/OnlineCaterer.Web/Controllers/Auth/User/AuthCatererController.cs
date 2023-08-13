using Microsoft.AspNetCore.Mvc;

namespace OnlineCaterer.Web.Controllers.Auth.User
{
    public class AuthCatererController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

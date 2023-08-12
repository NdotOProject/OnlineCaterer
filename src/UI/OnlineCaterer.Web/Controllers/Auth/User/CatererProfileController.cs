using Microsoft.AspNetCore.Mvc;

namespace OnlineCaterer.Web.Controllers.Auth.User
{
    public class CatererProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

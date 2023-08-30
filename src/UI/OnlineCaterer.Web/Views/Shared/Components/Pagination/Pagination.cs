using Microsoft.AspNetCore.Mvc;

namespace OnlineCaterer.Web.Views.Shared.Components.Pagination
{
    [ViewComponent]
    public class Pagination : ViewComponent
    {
        public IViewComponentResult Invoke(PaginationModel model)
        {
            return View("Pagination", model);
        }
	}
}

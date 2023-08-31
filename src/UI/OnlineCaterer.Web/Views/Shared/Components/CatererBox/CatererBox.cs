using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Web.Models.Caterer;

namespace OnlineCaterer.Web.Views.Shared.Components.CatererBox
{
	public class CatererBox : ViewComponent
	{
		public IViewComponentResult Invoke(CatererIndexViewModel model)
		{
			return View("CatererBox", model);
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Web.Views.Caterer;

namespace OnlineCaterer.Web.Views.Shared.Components.CatererBox
{
	public class CatererBox : ViewComponent
	{
		public IViewComponentResult Invoke(CatererIndexModel.CatererIndexViewModel model)
		{
			return View("CatererBox", model);
		}
	}
}

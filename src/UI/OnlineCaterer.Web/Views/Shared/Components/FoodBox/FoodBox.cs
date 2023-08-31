using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Web.Models.Food;
using OnlineCaterer.Web.Views.Food;

namespace OnlineCaterer.Web.Views.Shared.Components.FoodBox
{
	public class FoodBox : ViewComponent
	{
		public class DataHolder
		{
			public FoodIndexViewModel Food { get; set; }

			public string ReturnUrl { get; set; }
		}

		public DataHolder Food { get; set; }

		public IViewComponentResult Invoke(DataHolder model)
		{
			Food = model;
			return View("FoodBox", Food);
		}

	}
}

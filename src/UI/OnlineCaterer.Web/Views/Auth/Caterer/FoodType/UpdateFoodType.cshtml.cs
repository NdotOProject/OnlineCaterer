using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineCaterer.Web.Views.FoodType
{
    public class UpdateFoodType : PageModel
    {


        public class UpdateFoodTypeViewModel
        {
			public int Id { get; set; }

			public string Name { get; set; }

			public string Description { get; set; }

		}

        public UpdateFoodTypeViewModel UpdateModel { get; set; }

		public async Task OnGetAsync()
        {

        }

        public void OnPost()
        { 
        
        }
    }
}

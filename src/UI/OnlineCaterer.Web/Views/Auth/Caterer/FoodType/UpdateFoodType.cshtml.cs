using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Web.Models.FoodType;

namespace OnlineCaterer.Web.Views.FoodType
{
    public class UpdateFoodType : PageModel
    {


        public FoodTypeUpdateViewModel Input { get; set; }

		public /*async Task*/ void OnGetAsync()
        {

        }

        public void OnPost()
        { 
        
        }
    }
}

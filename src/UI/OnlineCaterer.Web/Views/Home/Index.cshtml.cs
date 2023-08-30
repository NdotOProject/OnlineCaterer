using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Web.Views.Auth.Caterer.FoodType;
using OnlineCaterer.Web.Views.Caterer;

namespace OnlineCaterer.Web.Views.Home
{
    public class IndexModel : PageModel
    {

        private readonly IRepository<Domain.Entities.FoodType> _foodTypeRepository;
        private readonly IRepository<Domain.Entities.Food> _foodRespoitory;
        private readonly IRepository<Domain.Entities.Caterer> _catererRepository;

        public IndexModel(
            IRepository<Domain.Entities.FoodType> foodTypeRepository,
            IRepository<Domain.Entities.Food> foodRespoitory,
            IRepository<Domain.Entities.Caterer> catererRepository)
        {
            _foodTypeRepository = foodTypeRepository;
            _foodRespoitory = foodRespoitory;
            _catererRepository = catererRepository;
        }

        public List<FoodTypeIndexModel.FoodTypeIndexViewModel> FoodTypes { get; set; }

        public List<CatererIndexModel.CatererIndexViewModel> Caterers { get; set; }


        public void OnGet()
        {
        }
    }
}

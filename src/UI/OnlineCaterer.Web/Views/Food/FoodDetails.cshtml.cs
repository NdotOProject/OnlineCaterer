using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Common.Interfaces.Data;

namespace OnlineCaterer.Web.Views.Food
{
    public class FoodDetailsModel : PageModel
    {
        public static readonly MapperConfiguration mapperConfiguration = new(config =>
            config.CreateProjection<Domain.Entities.Food, FoodDetailsViewModel>()
            .ForMember(vm => vm.FoodId, conf => conf.MapFrom(f => f.FoodId))
            .ForMember(vm => vm.Name, conf => conf.MapFrom(f => f.Name))
            .ForMember(vm => vm.CategoryId, conf => conf.MapFrom(f => f.CategoryId))
            .ForMember(vm => vm.Category, conf => conf.MapFrom(f => f.Category.Name))
            .ForMember(vm => vm.Price, conf => conf.MapFrom(f => f.Price))
            .ForMember(vm => vm.Discontinued, conf => conf.MapFrom(f => f.Discontinued))
            .ForMember(vm => vm.QuantityPerUnit, conf => conf.MapFrom(f => f.QuantityPerUnit))
            .ForMember(vm => vm.Description, conf => conf.MapFrom(f => f.Description))
        );

        private readonly IRepository<Domain.Entities.Food> _foodRepository;
        private readonly IRepository<Domain.Entities.FoodType> _foodTypeRepository;

		public FoodDetailsModel(
            IRepository<Domain.Entities.Food> foodRepository,
			IRepository<Domain.Entities.FoodType> foodTypeRepository)
        {
            _foodRepository = foodRepository;
            _foodTypeRepository = foodTypeRepository;
        }

        public class FoodDetailsViewModel : FoodIndexModel.FoodIndexViewModel
        {
            public string QuantityPerUnit { get; set; }

            public string Description { get; set; }

            public string? Caterers { get; set; }
        }

        public FoodDetailsViewModel FoodDetails { get; set; }

        public string ReturnUrl { get; private set; }

        public async Task OnGetAsync(
            [FromRoute(Name = "foodId")] int foodId, string returnUrl)
        {
            ReturnUrl = returnUrl;

            FoodDetails = await _foodRepository.GetQueryable()
                .Where(f => f.FoodId == foodId)
                .ProjectTo<FoodDetailsViewModel>(mapperConfiguration)
                .FirstAsync();

			FoodDetails.Caterers = await _foodTypeRepository.GetQueryable()
                .Where(ft => ft.Id.Equals(FoodDetails.CategoryId))
                .Select(ft => ft.Caterer.Name)
                .FirstAsync();

        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Constants;

namespace OnlineCaterer.Web.Views.Auth.Caterer.FoodType
{
    [Authorize(Roles = ConstantsRoles.Caterer)]
    public class FoodTypeIndexModel : PageModel
    {
		private const int PAGE_SIZE = 10;
		private readonly MapperConfiguration foodTypeMapperConfig = new(config =>
			config.CreateProjection<Domain.Entities.FoodType, FoodTypeIndexViewModel>()
/*			.ForMember(vm => vm.Id, )*/
		);

        private readonly IUser _user;
        private readonly IRepository<Domain.Entities.FoodType> _foodTypeRepository;

		public FoodTypeIndexModel(
			IRepository<Domain.Entities.FoodType> foodTypeRepository,
			IUser user)
		{
			_foodTypeRepository = foodTypeRepository;
			_user = user;
		}

		public class FoodTypeIndexViewModel
        {
			public int Id { get; set; }

			public string Name { get; set; }

			public string Description { get; set; }

		}

        public PaginatedList<FoodTypeIndexViewModel> FoodTypeList { get; set; }

		public async Task OnGetAsync()
        {
			FoodTypeList = await _foodTypeRepository.GetQueryable()
				.Where(ft => ft.CatererId.Equals(_user.Id))
				.ProjectTo<FoodTypeIndexViewModel>(foodTypeMapperConfig)
				.PaginatedListAsync(pageNumber: 1, pageSize: PAGE_SIZE);

        }
    }
}

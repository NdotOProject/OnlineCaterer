using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Data.Identity;
using OnlineCaterer.Domain.Constants;

namespace OnlineCaterer.Web.Views.Shared.Components.CategoryList
{
	[ViewComponent]
	public class FoodTypeList : ViewComponent
	{
		private readonly IUser _user;
		private readonly UserManager<ApplicationUser> _userManager;

		public FoodTypeList(IUser user, UserManager<ApplicationUser> userManager)
		{
			_user = user;
			_userManager = userManager;
		}

		public class FoodTypeListViewModel
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}

		private readonly MapperConfiguration foodTypeMapperConfig = new(config => 
			config.CreateProjection<Domain.Entities.FoodType, FoodTypeListViewModel>()
			.ForMember(vm => vm.Id, conf => conf.MapFrom(ft => ft.Id))
			.ForMember(vm => vm.Name, conf => conf.MapFrom(ft => ft.Name))
		);

		public async Task<IViewComponentResult> InvokeAsync(IRepository<Domain.Entities.FoodType> repository)
		{
			ApplicationUser? user = null;
			if (_user != null && _user.Id != null)
			{
				user = await _userManager.FindByIdAsync(_user.Id);
			}

			var queryable =  repository.GetQueryable();

			if (user != null && await _userManager.IsInRoleAsync(user, ConstantsRoles.Caterer))
			{
				queryable = queryable.Where(ft => ft.CatererId.Equals(user.Id));
			}

			var model = await queryable.OrderBy(ft => ft.Name)
				.ProjectTo<FoodTypeListViewModel>(foodTypeMapperConfig)
				.ToListAsync();

			return View("ListTypes", model);
		}
	}
}

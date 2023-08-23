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

namespace OnlineCaterer.Web.Views.Auth.Caterer.ResponseMessage
{
    [Authorize(Roles = ConstantsRoles.Caterer)]
    public class ListMessageModel : PageModel
    {
        private const int PAGE_SIZE = 10;
        private readonly MapperConfiguration mapperConfiguration = new(config =>
            config.CreateProjection<Domain.Entities.ResponseMessage, ResponseMessageIndexModel>()
            .ForMember(vm => vm.Id, conf => conf.MapFrom(rm => rm.Id))
            .ForMember(vm => vm.Title, conf => conf.MapFrom(rm => rm.Title))
            .ForMember(vm => vm.Content, conf => conf.MapFrom(rm => rm.Content))
            .ForMember(vm => vm.ResponseDate, conf => conf.MapFrom(rm => rm.ResponseDate))
        );

        private readonly IRepository<Domain.Entities.ResponseMessage> _respMessageRepository;
        private readonly IUser _user;

		public ListMessageModel(
            IUser user,
            IRepository<Domain.Entities.ResponseMessage> respMessageRepository)
		{
			_user = user;
			_respMessageRepository = respMessageRepository;
		}

        public class ResponseMessageIndexModel
        {
            public int Id { get; set; }

			public string Title { get; set; }

			public string Content { get; set; }

			public DateTime? ResponseDate { get; set; }
		}

		[BindProperty(SupportsGet = true, Name = PaginationQuery.Name)]
		public int? CurrentPage { get; set; }

        public PaginatedList<ResponseMessageIndexModel> ResponseMessages { get; set; }

        public async Task OnGetAsync()
        {
			ResponseMessages = await _respMessageRepository.GetQueryable()
                .Where(rm => rm.CatererId.Equals(_user.Id))
                .ProjectTo<ResponseMessageIndexModel>(mapperConfiguration)
                .PaginatedListAsync(pageNumber: CurrentPage ?? 1, pageSize: PAGE_SIZE);

        }
    }
}

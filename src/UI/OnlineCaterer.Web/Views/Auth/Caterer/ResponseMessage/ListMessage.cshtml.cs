using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Application.Common.Mappings;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Entities;

namespace OnlineCaterer.Web.Views.Auth.Caterer.ResponseMessage
{
    public class ListMessageModel : PageModel
    {
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

		[BindProperty(SupportsGet = true, Name = "p")]
		public int? CurrentPage { get; set; }

        public PaginatedList<ResponseMessageIndexModel> ResponseMessages { get; set; }

		public async Task OnGetAsync()
        {
            var configuration = new MapperConfiguration(config => 
            config.CreateProjection<Domain.Entities.ResponseMessage, ResponseMessageIndexModel>()
                .ForMember(vm => vm.Id, conf => conf.MapFrom(rm => rm.Id))
				.ForMember(vm => vm.Title, conf => conf.MapFrom(rm => rm.Title))
                .ForMember(vm => vm.Content, conf => conf.MapFrom(rm => rm.Content))
                .ForMember(vm => vm.ResponseDate, conf => conf.MapFrom(rm => rm.ResponseDate)));

			ResponseMessages = await _respMessageRepository.GetQueryable()
                .Where(rm => rm.CatererId.Equals(_user.Id))
                .ProjectTo<ResponseMessageIndexModel>(configuration)
                .PaginatedListAsync(pageNumber: CurrentPage ?? 1, pageSize: 10);

        }
    }
}

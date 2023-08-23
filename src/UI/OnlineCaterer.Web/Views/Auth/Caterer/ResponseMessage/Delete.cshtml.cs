using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCaterer.Domain.Constants;

namespace OnlineCaterer.Web.Views.Auth.Caterer.ResponseMessage
{
	[Authorize(Roles = ConstantsRoles.Caterer)]
	public class DeleteModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

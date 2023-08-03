
using OnlineCaterer.Application.Common.Interfaces;

using System.Security.Claims;

namespace OnlineCaterer.Web.Services;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? Id => _httpContextAccessor.HttpContext?
        .User?.FindFirstValue(ClaimTypes.NameIdentifier);
}

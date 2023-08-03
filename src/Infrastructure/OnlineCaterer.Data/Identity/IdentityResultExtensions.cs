using Microsoft.AspNetCore.Identity;
using OnlineCaterer.Application.Common.Models;

namespace OnlineCaterer.Data.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}

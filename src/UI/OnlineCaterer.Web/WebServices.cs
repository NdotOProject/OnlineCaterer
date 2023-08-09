
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Web.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class WebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {

        services.AddRazorPages(options =>
        {

        });

        //services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        return services;
    }
}

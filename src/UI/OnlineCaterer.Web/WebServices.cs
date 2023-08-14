
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Web.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class WebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {

        services.AddRazorPages(options =>
        {
            options.RootDirectory = "/Views";
        });

        //services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        services.ConfigureApplicationCookie(options => {
            //options.LoginPath = "/login/";
            //options.LogoutPath = "/logout/";
            //options.AccessDeniedPath = "/khongduoctruycap.html";
        });

        return services;
    }
}

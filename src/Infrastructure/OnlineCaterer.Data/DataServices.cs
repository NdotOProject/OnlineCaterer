
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Data;
using OnlineCaterer.Data.Identity;
using OnlineCaterer.Data.Interceptors;

namespace Microsoft.Extensions.DependencyInjection;

public static class DataServices
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ISaveChangesInterceptor, ModifiedEntityInterceptor>();

        // 
        services.AddDbContext<ApplicationDbContext>(options => {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddTransient<IIdentityService, IdentityService>();

        return services;
    }
}

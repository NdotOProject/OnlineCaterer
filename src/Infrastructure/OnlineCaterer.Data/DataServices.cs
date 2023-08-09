
using Microsoft.EntityFrameworkCore.Diagnostics;
using OnlineCaterer.Data.Interceptors;
using OnlineCaterer.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class DataServices
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ISaveChangesInterceptor, ModifiedEntityInterceptor>();

        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) => {

            options.AddInterceptors(serviceProvider.GetServices<ISaveChangesInterceptor>());

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddTransient<IIdentityService, IdentityService>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}

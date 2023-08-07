
namespace Microsoft.Extensions.DependencyInjection;

public static class DataServices
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {

        //services.AddScoped<ISaveChangesInterceptor, ModifiedEntityInterceptor>();

        
        services.AddDbContext<ApplicationDbContext>(options => {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });
        

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitialiser>();

        //services.AddTransient<IIdentityService, IdentityService>();

        return services;
    }
}

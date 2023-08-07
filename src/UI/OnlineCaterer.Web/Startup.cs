
using Microsoft.AspNetCore.Identity;
using OnlineCaterer.Data.Identity;
using OnlineCaterer.Data.Context;

namespace OnlineCaterer.Web;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        //
        services.AddOptions();
        services.AddSingleton<IConfiguration>(Configuration);

        services.AddRazorPages();

        //services.Configure<List<Role>>(Configuration.GetSection("Initialization").GetSection("Roles"));
        //
        services.AddApplicationServices();
        services.AddDataServices(Configuration);
        services.AddInfrastructureServices(Configuration);
        services.AddWebServices();

        //
        /*services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();*/

        services.AddDefaultIdentity<ApplicationUser>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        //
        services.AddControllersWithViews();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        if (env.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
            app.InitialDatabase();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        app.UseAuthentication();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
        });

    }
}

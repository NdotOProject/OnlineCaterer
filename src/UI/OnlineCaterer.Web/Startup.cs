
using Microsoft.AspNetCore.Identity;
using OnlineCaterer.Data.Identity;
using OnlineCaterer.Data.Context;
using OnlineCaterer.Web.Services;
using OnlineCaterer.Application.Common.Interfaces;

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
        services.AddSingleton(Configuration);

        services.AddSingleton(CompanyInfoReader.GetCompanyInfo());

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		services.AddDistributedMemoryCache();

		services.AddSession(option =>
		{
			option.Cookie.Name = "SESSIONID";
			option.IdleTimeout = TimeSpan.FromDays(7);
		});

		services.AddRazorPages(options =>
		{
			options.RootDirectory = "/Views";
		});

		//services.AddDatabaseDeveloperPageExceptionFilter();

		services.AddScoped<IUser, CurrentUser>();

		services.AddHttpContextAccessor();

		// registor identity
		services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        /*
        services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        */

        // Identity config
        services.Configure<IdentityOptions>(options =>
        {
            // password setting
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequiredLength = 3; // password has min lenght equal to 3

            // lockout setting
            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

            // user setting
            options.User.AllowedUserNameCharacters
                = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;

            // login setting
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedAccount = false;

        });

        services.ConfigureApplicationCookie(options => {
            options.LoginPath = "/login/";
            options.LogoutPath = "/logout/";
            options.AccessDeniedPath = "/accessdenied/";
        });

        //
        services.AddApplicationServices();
        services.AddDataServices(Configuration);
        services.AddInfrastructureServices(Configuration);

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

        app.UseSession();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            /*endpoints.MapGet("/", async context =>
            {
            });*/
            endpoints.MapRazorPages();
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
        });

    }
}

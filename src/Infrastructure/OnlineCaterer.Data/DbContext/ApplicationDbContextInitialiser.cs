
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnlineCaterer.Application.Initialization;

namespace OnlineCaterer.Data.Context;

public static class InitialiserExtensions
{
    public static async void InitialDatabase(this IApplicationBuilder app)
    {
        var scopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();

        using var scope = scopeFactory?.CreateScope();
        if (scope != null)
        {
            var initialiser = scope.ServiceProvider.GetService<ApplicationDbContextInitialiser>();

            if (initialiser != null)
            {
                await initialiser.Initialise();
                await initialiser.InitRoles(roles: Initialization.Roles);
                await initialiser.InitUsers(users: Initialization.Users);
            }
        }
    }

}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationDbContextInitialiser(
        ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context,
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager
        )
    {
        _logger = logger;
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task Initialise()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "An error occurred during database initialization");
            throw;
        }
    }

    public async Task InitRoles(List<Role> roles)
    {
        if (!_context.Roles.Any() && roles != null)
        {

            var identityRoles = new List<IdentityRole>();

            foreach (var role in roles)
            {
                identityRoles.Add(new IdentityRole
                {
                    Name = role.Name,
                    NormalizedName = role.NormalizedName,
                });
            }

            foreach (var role in identityRoles)
            {
                await _roleManager.CreateAsync(role);
            }
        }
    }

    public async Task InitUsers(List<User> users)
    {
        if (!_context.Users.Any() && users != null)
        {
            if (!_context.Caterers.Any() && !_context.Customers.Any())
            {
                foreach (var user in users)
                {
                    var identityUser = new ApplicationUser
                    {
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        UserName = user.UserName,
                    };

                    await _userManager.CreateAsync(identityUser, user.Password);

                    if (user.Roles != null)
                    {
                        await _userManager.AddToRolesAsync(identityUser, user.Roles);
                    }

                    if (user.CatererInfo != null)
                    {
                        var caterer = user.CatererInfo;
                        if (caterer != null)
                        {
                            caterer.UserId = identityUser.Id;

                            _context.Caterers.Add(caterer);
                            await _context.SaveChangesAsync();
                        }
                    }
                    if (user.CustomerInfo != null)
                    {
                        var customer = user.CustomerInfo;
                        if (customer != null)
                        {
                            customer.UserId = identityUser.Id;

                            _context.Customers.Add(customer);
                            await _context.SaveChangesAsync();
                        }
                    }

                }
            }
        }
    }

}

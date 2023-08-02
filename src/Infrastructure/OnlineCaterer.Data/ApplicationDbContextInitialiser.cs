
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnlineCaterer.Data.Identity;

namespace OnlineCaterer.Data;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(
        ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager
        )
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
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
    public async Task SeedAsync(IConfiguration configuration)
    {
        try
        {
            await TrySeedAsync(configuration);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync(IConfiguration configuration)
    {
        // Initial roles
        var roles = configuration.GetSection("Roles");
        var adminRole = new IdentityRole(roles.GetSection("Administrator").Value);
        await _roleManager.CreateAsync(adminRole);

        var customerRole = new IdentityRole(roles.GetSection("Customer").Value);
        await _roleManager.CreateAsync(customerRole);

        var catererRole = new IdentityRole(roles.GetSection("Caterer").Value);
        await _roleManager.CreateAsync(catererRole);

        // Initial Admin
        var adminInfo = configuration.GetSection("Admin");
        var admin = new ApplicationUser
        {
            Email = adminInfo.GetSection("Email").Value,
            EmailConfirmed = true,
            PhoneNumber = adminInfo.GetSection("PhoneNumber").Value,
            PhoneNumberConfirmed = true,

            UserName = adminInfo.GetSection("UserName").Value
        };

        await _userManager.CreateAsync(admin, adminInfo.GetSection("Password").Value);
        if (!string.IsNullOrWhiteSpace(adminRole.Name))
        {
            await _userManager.AddToRoleAsync(admin, adminRole.Name);
        }

    }
}

public static class InitialiserExtensions
{
    public static async Task InitialDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync(app.Configuration);

    }
}

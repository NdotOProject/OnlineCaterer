
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OnlineCaterer.Data;

public static class InitialiserExtensions
{
    public static void InitialDatabase(this IApplicationBuilder app, IConfiguration configuration)
    {
        var scopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();

        using var scope = scopeFactory?.CreateScope();
        if (scope != null)
        {
            var initialiser = scope.ServiceProvider.GetService<ApplicationDbContextInitialiser>();

            if (initialiser != null)
            {
                initialiser.Initialise();
                //initialiser.Seed(configuration);
            }
        }
    }

}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    //private readonly UserManager<ApplicationUser> _userManager;
    //private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(
        ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context//,
        //UserManager<ApplicationUser> userManager,
        //RoleManager<IdentityRole> roleManager
        )
    {
        _logger = logger;
        _context = context;
        //_userManager = userManager;
        //_roleManager = roleManager;
    }

    public void Initialise()
    {
        try
        {
            _context.Database.Migrate();
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "An error occurred during database initialization");
            throw;
        }
    }
/*    
    public void Seed(IConfiguration configuration)
    {
        try
        {
            TrySeed(configuration);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public void TrySeed(IConfiguration configuration)
    {
        var initialization = configuration.GetSection("Initialization");

        // Initial roles
        var roles = SeedRoles(initialization);

        // Initial Caterers
        SeedCaterer(initialization, roles);

    }

    public void SeedCaterer(IConfiguration initialization, ICollection<Role>? roles)
    {
        // Initial Caterers
        var caterersConfig = initialization.GetSection("Caterers");
        var caterers = JsonConvert.DeserializeObject<ICollection<ShortCatererResponse>>(caterersConfig.Value ?? "[]");
        if (caterers != null && caterers.Count > 0)
        {
            foreach (var caterer in caterers)
            {
                var catererAppUser = new ApplicationUser
                {
                    Name = caterer.Name,
                    Address = caterer.Address,
                    Email = caterer.Email,
                    PhoneNumber = caterer.PhoneNumber,
                    UserName = caterer.UserName,
                };

                _userManager.CreateAsync(catererAppUser, caterer.Password ?? "123456");

                if (roles != null)
                {
                    var catererRole = roles.Where(r => r.User != null && r.User.Equals("Caterer")).Select(r => r.Name).First();
                    if (catererRole != null)
                    {
                         _userManager.AddToRoleAsync(catererAppUser, catererRole);
                    }
                }

                _context.Users.Add(catererAppUser);
                _context.Caterers.Add(new Caterer
                {
                    UserId = catererAppUser.Id,
                    CreatedBy = catererAppUser.Id,
                    LastModifiedBy = catererAppUser.Id,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                });
                _context.SaveChanges();

            }

        }
    }

    public ICollection<Role>? SeedRoles(IConfiguration initialization)
    {
        // Initial roles
        var rolesConfig = initialization.GetRequiredSection("Roles");
        var roles = JsonConvert.DeserializeObject<ICollection<Role>>(rolesConfig.Value ?? "[]");
        if (roles != null && roles.Count > 0)
        {
            foreach (var role in roles)
            {
                var roleName = role.Name;
                if (roleName != null)
                {
                    var identityRole = new IdentityRole(roleName);
                     _roleManager.CreateAsync(identityRole);

                     _context.Roles.Add(identityRole);
                }

                _context.SaveChanges();
            }

        }
        return roles;
    }
*/
}

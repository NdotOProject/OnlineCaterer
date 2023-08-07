
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OnlineCaterer.Data.Context;

public static class InitialiserExtensions
{
    public static void InitialDatabase(this IApplicationBuilder app)
    {
        var scopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();

        using var scope = scopeFactory?.CreateScope();
        if (scope != null)
        {
            var initialiser = scope.ServiceProvider.GetService<ApplicationDbContextInitialiser>();

            if (initialiser != null)
            {
                initialiser.Initialise();
            }
        }
    }

}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(
        ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context
        )
    {
        _logger = logger;
        _context = context;
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

}


using Microsoft.Extensions.Configuration;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Domain.Constants;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // registor mail service
        var mailSetting = configuration.GetRequiredSection("MailSettings");
        services.Configure<MailSettings>(mailSetting);
        services.AddSingleton<IEmailSender, MailService>();

        //
        services.AddTransient<IDateTime, DateTimeService>();

        //
        services.AddAuthentication();

        // 
        var policies = new List<Policy>(new Policy[]
        {
            new Policy
            {
                Name = "UpdateProfile",
                RequireRoles = new List<string>(new string[]
                {
                    ConstantsRoles.Caterer,
                    ConstantsRoles.Customer
                })
            }
        });
        services.AddAuthorization(options =>
        {
            if (policies != null && policies.Count > 0)
            {
                foreach (var policy in policies)
                {
                    if (policy.Name != null && policy.RequireRoles != null)
                    {
                        options.AddPolicy(policy.Name, policyBuilder =>
                        {
                            policyBuilder.RequireRole(policy.RequireRoles);
                        });
                    }
                }
            }
            // other policies
        });

        //

        return services;
    }
}

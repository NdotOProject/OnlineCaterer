
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Application.Common.Models;
using OnlineCaterer.Application.Common.Models.Mail;
using OnlineCaterer.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddTransient<IDateTime, DateTimeService>();

        /*var policies = JsonConvert.DeserializeObject<ICollection<Policy>>(
            configuration.GetSection("Policies").Value ?? "[]"
        );*/
        services.AddAuthentication();

        var policies = new LinkedList<Policy>();
        services.AddAuthorization(options =>
        {
            if (policies != null && policies.Count > 0)
            {
                foreach (var policy in policies)
                {
                    if (policy.Name != null && policy.RequireRole != null)
                    {
                        options.AddPolicy(policy.Name, policyBuilder =>
                        {
                            policyBuilder.RequireRole(policy.RequireRole);
                        });
                    }
                }
            }
            // other policies
        });

        // regis mail service
        var mailSetting = configuration.GetRequiredSection("MailSettings");
        services.Configure<MailSettings>(mailSetting);
        services.AddSingleton<IEmailSender, MailService>();

        return services;
    }
}

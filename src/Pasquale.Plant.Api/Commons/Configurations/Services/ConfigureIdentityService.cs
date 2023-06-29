using Microsoft.AspNetCore.Identity;
using Pasquale.Plant.Api.Commons.Helpers;
using Pasquale.Plant.Api.Domains.Entities;
using Pasquale.Plant.Api.Persistences.Contexts;
using Pasquale.Plant.Api.Services;

namespace Pasquale.Plant.Api.Commons.Configurations.Services;

public static class ConfigureIdentityService
{
    public static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, Role>(
                options =>
                {
                    options.User.RequireUniqueEmail = false;
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 3;
                    options.Password.RequiredLength = 8;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.SignIn.RequireConfirmedEmail = true;
                    options.Tokens.EmailConfirmationTokenProvider = configuration["AppSetting:Identity"]!;
                })
            .AddEntityFrameworkStores<DefaultContext>()
            .AddErrorDescriber<IdentityErrorHelper>()
            .AddTokenProvider<IdentityEmailService<User>>(configuration["AppSetting:Identity"]!)
            .AddDefaultTokenProviders();

        services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromMinutes(5));
    }
}
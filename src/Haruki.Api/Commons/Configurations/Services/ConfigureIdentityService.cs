using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Helpers;
using Haruki.Api.Domains.Entities;
using Haruki.Api.Persistences.Contexts;
using Haruki.Api.Services;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Commons.Configurations.Services;

public static class ConfigureIdentityService
{
    public static void AddIdentityService(this IServiceCollection services)
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
                    options.Tokens.EmailConfirmationTokenProvider = SettingConstant.Identity;
                })
            .AddEntityFrameworkStores<DefaultContext>()
            .AddErrorDescriber<IdentityErrorHelper>()
            .AddTokenProvider<IdentityEmailService<User>>(SettingConstant.Identity)
            .AddDefaultTokenProviders();

        services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromMinutes(5));
    }
}
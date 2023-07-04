using System.Text;
using Haruki.Api.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Haruki.Api.Commons.Configurations.Services;

public static class ConfigureAuthenticationService
{
    public static void AddAuthenticationService(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = SettingConstant.JwtIssuer,
                    ValidAudience = SettingConstant.JwtAudience,
                    ValidAudiences = new []{ SettingConstant.JwtAudience },
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SettingConstant.JwtSecret))
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Log.Error(context.Exception, "{ExceptionMessage} - {ExceptionInnerException}", context.Exception.Message, context.Exception.InnerException);
                        return Task.CompletedTask;
                    }
                };
            })
            .AddGoogle(options =>
            {
                options.ClientId = SettingConstant.GoogleAuthKey;
                options.ClientSecret = SettingConstant.GoogleAuthSecret;
            });
    }
}
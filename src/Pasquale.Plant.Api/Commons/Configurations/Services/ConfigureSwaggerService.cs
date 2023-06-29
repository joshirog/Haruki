using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Pasquale.Plant.Api.Commons.Configurations.Services;


public static class ConfigureSwaggerService
{
    public static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Enter JWT Bearer token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securityScheme, Array.Empty<string>() }
            });
            c.EnableAnnotations();
            c.TagActionsBy(api =>
            {
                if (api.GroupName != null)
                {
                    return new[] { api.GroupName };
                }

                if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                {
                    return new[] { controllerActionDescriptor.ControllerName };
                }

                throw new InvalidOperationException("Unable to determine tag for endpoint.");
            });
            c.DocInclusionPredicate((_, _) => true);
        });
        
        services.ConfigureOptions<ConfigureSwaggerOptions>();
    }
}

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(
        IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                CreateVersionInfo(description));
        }
    }
    
    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }
    
    private static OpenApiInfo CreateVersionInfo(
        ApiVersionDescription desc)
    {
        var info = new OpenApiInfo()
        {
            Title = "Planta API",
            Version = desc.ApiVersion.ToString(),
            Description = "An API to managements tasks",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Jose Oshiro",
                Email = "joshirog@gmail.com",
                Url = new Uri("https://github.com/joshirog"),
            },
            License = new OpenApiLicense
            {
                Name = "API LICX",
                Url = new Uri("https://example.com/license"),
            }
        };

        if (desc.IsDeprecated)
        {
            info.Description += " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
        }

        return info;
    }
}
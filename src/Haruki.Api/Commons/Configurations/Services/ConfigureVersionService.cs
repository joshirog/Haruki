using Microsoft.AspNetCore.Mvc;

namespace Haruki.Api.Commons.Configurations.Services;

public static class ConfigureVersionService
{
    public static void AddVersionService(this IServiceCollection services)
    {
        services.AddApiVersioning(opt => 
        { 
            opt.DefaultApiVersion = new ApiVersion(1, 0); 
            opt.AssumeDefaultVersionWhenUnspecified = true; 
            opt.ReportApiVersions = true;
        }); 

        services.AddVersionedApiExplorer(setup => 
        { 
            setup.GroupNameFormat = "'v'VVV" ;
            setup.SubstituteApiVersionInUrl = true; 
        });
    }
}
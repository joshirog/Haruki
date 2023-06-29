using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Haruki.Api.Commons.Configurations.Applications;

public static class ConfigureSwaggerApplication
{
    public static void AddSwaggerApplication(this WebApplication app)
    {
        //if (!app.Environment.IsDevelopment()) 
        //return;

        app.UseSwagger();
        
        app.UseSwaggerUI(options =>
        {
            foreach (var description in app.Services.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Pasquale.Plant.Api.Commons.Filters;

namespace Pasquale.Plant.Api.Commons.Configurations.Services;

public static class ConfigureControllerService
{
    public static void AddControllerService(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<ExceptionFilter>();
        });
        
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
        
        services.AddRouting(options => options.LowercaseUrls = true);
        
        services.AddResponseCompression(options =>
        {
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
        });
    }
}
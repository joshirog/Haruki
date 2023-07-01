using System.Net.Http.Headers;
using System.Net.Mime;
using Haruki.Api.Commons.Constants;

namespace Haruki.Api.Commons.Configurations.Services;

public static class ConfigureHttpClientService
{
    public static void AddHttpClientService(this IServiceCollection services)
    {
        services.AddHttpClient(EndpointConstant.SendInBlue, c =>
        {
            c.BaseAddress = new Uri(EndpointConstant.SendInBlueEndpoint);
            c.DefaultRequestHeaders.Connection.Add(GeneralConstant.KeepAlive);
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            c.DefaultRequestHeaders.Add(GeneralConstant.ApiKey, SettingConstant.SendInBlueApiKey);
        });
    }
}
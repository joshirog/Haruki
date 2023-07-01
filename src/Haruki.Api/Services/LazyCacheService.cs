using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Helpers;
using Haruki.Api.Commons.Interfaces;
using Haruki.Api.Domains.Entities;
using LazyCache;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Services;

public class LazyCacheService : ICacheService
{
    private readonly IAppCache _cache;
    private readonly SignInManager<User> _signInManager;


    public LazyCacheService(IAppCache cache, SignInManager<User> signInManager)
    {
        _cache = cache;
        _signInManager = signInManager;
    }

    public string Template(string key)
    {
        var result = _cache.GetOrAdd(key, entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromDays(1);
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);

            using var httpClient = new HttpClient();
            
            return key switch
            {
                nameof(SettingConstant.TemplateActivation) => HttpClientHelper.DownloadString(httpClient, SettingConstant.TemplateActivation),
                nameof(SettingConstant.TemplateWelcome) => HttpClientHelper.DownloadString(httpClient, SettingConstant.TemplateWelcome),
                nameof(SettingConstant.TemplatePassword) => HttpClientHelper.DownloadString(httpClient, SettingConstant.TemplatePassword),
                nameof(SettingConstant.TemplateOtp) => HttpClientHelper.DownloadString(httpClient, SettingConstant.TemplateOtp),
                nameof(SettingConstant.TemplateReset) => HttpClientHelper.DownloadString(httpClient, SettingConstant.TemplateReset),
                nameof(SettingConstant.TemplateLocked) => HttpClientHelper.DownloadString(httpClient, SettingConstant.TemplateLocked),
                _ => null
            };
        });

        return result;
    }

    public async Task<List<AuthenticationScheme>> ExternalLogin()
    {
        var result = await _cache.GetOrAdd("ExternalLogin", entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromDays(1);
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
            
            return _signInManager.GetExternalAuthenticationSchemesAsync();
        });

        return result.ToList();
    }

    public void Remove(string key)
    {
        _cache.Remove(key);
    }
}
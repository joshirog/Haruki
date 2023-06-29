using System.Security.Claims;
using Haruki.Api.Commons.Interfaces;

namespace Haruki.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string UserId => _httpContextAccessor.HttpContext?.User.FindFirstValue("id") ?? "0";
    
    public string UserName => _httpContextAccessor.HttpContext?.User.FindFirstValue("username") ?? "system@haruki.com";

    //public List<string> Roles => _securityService.GetRoles(UserId, _configurationService.GetSecurityServiceApplicationId().ToString()).Result;
}
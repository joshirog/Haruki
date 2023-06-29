using System.Security.Claims;
using Pasquale.Plant.Api.Commons.Interfaces;

namespace Pasquale.Plant.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string UserId => _httpContextAccessor.HttpContext?.User.FindFirstValue("id") ?? "";

    //public List<string> Roles => _securityService.GetRoles(UserId, _configurationService.GetSecurityServiceApplicationId().ToString()).Result;
}
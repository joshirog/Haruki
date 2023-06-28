using System.Security.Claims;
using Pasquale.Planta.Api.Commons.Interfaces;

namespace Pasquale.Planta.Api.Services;

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
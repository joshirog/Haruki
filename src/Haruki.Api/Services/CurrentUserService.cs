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

    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
    
    public string UserId => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Sid))?.Value ?? string.Empty;
    
    public string UserName => _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "system@haruki.com";

    public string Role => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value ?? string.Empty;

    public string Token => _httpContextAccessor.HttpContext?.Request.Headers["Authorization"];
}
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
    
    public string UserName => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value ?? string.Empty;
    
    public string Role => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value ?? string.Empty;
    
    public string Name => _httpContextAccessor.HttpContext?.User.Identity?.Name ?? string.Empty;
    
    public string SurName => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Surname))?.Value ?? string.Empty;
    
    public string GivenName => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.GivenName))?.Value ?? string.Empty;
    
    public string Avatar => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.UserData))?.Value ?? string.Empty;

    public string Token => _httpContextAccessor.HttpContext?.Request.Headers["Authorization"];
}
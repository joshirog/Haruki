using System.Reflection;
using Haruki.Api.Commons.Filters;
using Haruki.Api.Commons.Interfaces;
using MediatR;

namespace Haruki.Api.Commons.Behaviours;


public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUserService;

    public AuthorizationBehaviour(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeFilter>();

        if (authorizeAttributes.Any()) 
            return await next();
 
        if (string.IsNullOrEmpty(_currentUserService.UserId))
        {
            throw new UnauthorizedAccessException();
        }
        
        /*
        var appId = _configurationService.GetSecurityServiceApplicationId();

        var accessList = await _securityService.ValidateUserAccess(userId, appId.ToString());

        if (accessList is null)
        {
            throw new ForbiddenAccessException();
        }

        var reqname = typeof(TRequest).Name;

        if (!accessList.Contains(reqname))
        {
            throw new ForbiddenAccessException();
        }
        */

        return await next();
    }
}
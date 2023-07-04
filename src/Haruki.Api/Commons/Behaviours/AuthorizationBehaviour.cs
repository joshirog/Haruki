using Haruki.Api.Commons.Exceptions;
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
        if (string.IsNullOrEmpty(_currentUserService.Token))
            throw new UnauthorizedAccessException();
        
        if(!_currentUserService.IsAuthenticated)
            throw new UnauthorizedAccessException();
 
        if (string.IsNullOrEmpty(_currentUserService.UserId))
            throw new UnauthorizedAccessException();
        
        if (string.IsNullOrEmpty(_currentUserService.UserName))
            throw new UnauthorizedAccessException();
        
        if (string.IsNullOrEmpty(_currentUserService.Role))
            throw new ForbiddenAccessException();
        
        return await next();
    }
}
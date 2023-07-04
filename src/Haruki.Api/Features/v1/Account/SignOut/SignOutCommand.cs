using Haruki.Api.Domains.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Features.v1.Account.SignOut;

public class SignOutCommand : IRequest
{
    
}

public class SignOutHandler : IRequestHandler<SignOutCommand>
{
    private readonly SignInManager<User> _signInManager;

    public SignOutHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }
        
    public async Task<Unit> Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
            
        return await Task.FromResult(Unit.Value);
    }
}
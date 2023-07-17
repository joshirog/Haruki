using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Domains.Entities;
using Haruki.Api.Features.v1.Authentication.SignIn;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Features.v1.Authentication.TwoFactor;

public class TwoFactorCommand : IRequest<ResponseBase<bool>>
{
    public TwoFactorCommand(Guid id)
    {
        Id = id;
    }

    public TwoFactorCommand(Guid id, string code1, string code2, string code3, string code4, string code5, string code6)
    {
        Id = id;
        Code1 = code1;
        Code2 = code2;
        Code3 = code3;
        Code4 = code4;
        Code5 = code5;
        Code6 = code6;
    }

    public Guid Id { get; }
        
    public string Code1 { get; }
        
    public string Code2 { get; }
        
    public string Code3 { get; }
        
    public string Code4 { get; }
        
    public string Code5 { get; }
        
    public string Code6 { get; }
}

public class TwoFactorHandler : IRequestHandler<TwoFactorCommand, ResponseBase<bool>>
{
    private readonly IMediator _mediator;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public TwoFactorHandler(IMediator mediator, SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _mediator = mediator;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    public async Task<ResponseBase<bool>> Handle(TwoFactorCommand request, CancellationToken cancellationToken)
    {
        var code = $"{request.Code1}{request.Code2}{request.Code3}{request.Code4}{request.Code5}{request.Code6}";
        
        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

        if (user is null)
            return Response.Fail(ResponseConstant.MessageTwoFactorFail, false);
            
        var result = await _signInManager.TwoFactorSignInAsync(GeneralConstant.ProviderEmail, code, true, false);
            
        if (result.Succeeded)
        {
            await _userManager.ResetAccessFailedCountAsync(user);
                
            await _userManager.UpdateSecurityStampAsync(user);

            return Response.Ok(ResponseConstant.MessageSuccess, true);
        }

        if (result.IsNotAllowed)
            return Response.Fail(ResponseConstant.MessageConfirm, false);

        if (result.IsLockedOut)
        {
            await _mediator.Publish(new SignInNotification { UserName = user.UserName }, cancellationToken);
            return Response.Fail(ResponseConstant.MessageLockedAccount, false);
        }

        if (result.RequiresTwoFactor)
            return Response.Fail(ResponseConstant.MessageTwoFactorError, false);

        return Response.Fail(ResponseConstant.MessageTwoFactorFail, false);
    }
}
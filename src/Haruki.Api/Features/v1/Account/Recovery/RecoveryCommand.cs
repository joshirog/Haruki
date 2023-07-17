using System.Text;
using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Domains.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace Haruki.Api.Features.v1.Account.Recovery;

public class RecoveryCommand : IRequest<ResponseBase<bool>>
{
    public RecoveryCommand(string email, string returnUrl)
    {
        Email = email;
        ReturnUrl = returnUrl;
    }

    public string Email { get; }

    public string ReturnUrl { get; }
}

public class RecoveryHandler : IRequestHandler<RecoveryCommand, ResponseBase<bool>>
{
    private readonly IMediator _mediator;
    private readonly UserManager<User> _userManager;

    public RecoveryHandler(IMediator mediator, UserManager<User> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
    }
    
    public async Task<ResponseBase<bool>> Handle(RecoveryCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        
        if(user is null)
            return Response.Fail("We have sent the email instructions to follow and recover the password.", false);

        var claims = await _userManager.GetClaimsAsync(user);
        var firstname = claims.Where(x => x.Type.Equals("first_name")).Select(x => x.Value).FirstOrDefault();

        await _userManager.UpdateSecurityStampAsync(user);
        
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var tokenEncodedBytes = Encoding.UTF8.GetBytes(token);
        var tokenEncoded = WebEncoders.Base64UrlEncode(tokenEncodedBytes);
        
        var callback = $"{SettingConstant.WebUrl}/{SettingConstant.WebRouteReset}/{user.Id}?token={tokenEncoded}&returnUrl={request.ReturnUrl}";
        
        await _mediator.Publish(new RecoveryNotification
        {
            Name = firstname,
            Email = user.Email,
            Callback = callback
        }, cancellationToken);

        return Response.Ok(ResponseConstant.MessageChangePassword, true);
    }
}
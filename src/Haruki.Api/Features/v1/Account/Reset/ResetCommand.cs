using System.Text;
using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Domains.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace Haruki.Api.Features.v1.Account.Reset;

public class ResetCommand : IRequest<ResponseBase<bool>>
{
    public ResetCommand(string userId, string token)
    {
        UserId = userId;
        Token = token;
    }
    
    public ResetCommand(string userId, string token, string password, string confirmPassword)
    {
        UserId = userId;
        Token = token;
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public string UserId { get; }

    public string Token { get; }

    public string Password { get; }

    public string ConfirmPassword { get; }
}

public class ResetHandler : IRequestHandler<ResetCommand, ResponseBase<bool>>
{
    private readonly IMediator _mediator;
    private readonly UserManager<User> _userManager;

    public ResetHandler(IMediator mediator, UserManager<User> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
    }

    public async Task<ResponseBase<bool>> Handle(ResetCommand request, CancellationToken cancellationToken)
    {
        var tokenDecodedBytes = WebEncoders.Base64UrlDecode(request.Token);
        var tokenDecoded = Encoding.UTF8.GetString(tokenDecodedBytes);

        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user is null)
            throw new Exception($"User {request.UserId} not exist");

        var result = await _userManager.ResetPasswordAsync(user, tokenDecoded, request.Password);

        if (!result.Succeeded)
            return Response.Fail(ResponseConstant.MessageFail, false);

        await _mediator.Publish(new ResetNotification { UserId = request.UserId }, cancellationToken);

        return Response.Ok(ResponseConstant.MessageSuccessPassword, result.Succeeded);
    }
}
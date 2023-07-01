using System.Text;
using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Domains.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace Haruki.Api.Features.v1.Account.Confirm;

public class ConfirmCommand : IRequest<ResponseBase<bool>>
{
    public ConfirmCommand(string userId, string token)
    {
        UserId = userId;
        Token = token;
    }

    public string UserId { get; }

    public string Token { get; }
}

public class ConfirmHandler : IRequestHandler<ConfirmCommand, ResponseBase<bool>>
{
    private readonly IMediator _mediator;
    private readonly UserManager<User> _userManager;

    public ConfirmHandler(IMediator mediator, UserManager<User> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
    }
        
    public async Task<ResponseBase<bool>> Handle(ConfirmCommand request, CancellationToken cancellationToken)
    {
        var tokenDecodedBytes = WebEncoders.Base64UrlDecode(request.Token);
        var tokenDecoded = Encoding.UTF8.GetString(tokenDecodedBytes);
            
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user is null)
            return Response.Fail($"User {request.UserId} not exist", false);
        
        var result = await _userManager.ConfirmEmailAsync(user, tokenDecoded);

        if (!result.Succeeded) 
            return Response.Fail(result.Errors.Select(x => x.Description).FirstOrDefault(), result.Succeeded);
        
        await _mediator.Publish(new ConfirmNotification{ UserId = request.UserId }, cancellationToken);
        
        return Response.Ok(ResponseConstant.MessageSuccess, result.Succeeded);
    }
}
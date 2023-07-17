using System.Security.Claims;
using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Enums;
using Haruki.Api.Domains.Entities;
using Haruki.Api.Features.v1.Authentication.Confirm;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Features.v1.Authentication.External;

public class CallbackCommand : IRequest<ResponseBase<bool>>
{
    public CallbackCommand(string remoteError)
    {
        RemoteError = remoteError;
    }

    public string ReturnUrl { get; set; }

    public string RemoteError { get; }
}

public class CallbackCommandHandler : IRequestHandler<CallbackCommand, ResponseBase<bool>>
{
    private readonly IMediator _mediator;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public CallbackCommandHandler(IMediator mediator, SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _mediator = mediator;
        _signInManager = signInManager;
        _userManager = userManager;
    }
        
    public async Task<ResponseBase<bool>> Handle(CallbackCommand request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.RemoteError))
            return Response.Fail($"{ResponseConstant.MessageErrorProvider} : {request.RemoteError}", false);

        var info = await _signInManager.GetExternalLoginInfoAsync();

        if (info is null)
            return Response.Fail(ResponseConstant.MessageFail, false);
        
        var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false, true);

        if (signInResult.Succeeded)
        {
            return Response.Ok(ResponseConstant.MessageSuccessConfirm, true);
        }
        
        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        var identifier = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
        var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
        var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname);
        
        Console.WriteLine($"Callback email : {email}");
        Console.WriteLine($"Callback identifier : {identifier}");
        Console.WriteLine($"Callback firstName : {firstName}");
        Console.WriteLine($"Callback lastName : {lastName}");

        if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(identifier))
            return Response.Fail(ResponseConstant.MessageFail, false);

        User user;
        var isCreated = false;
        
        if (email is not null)
        {
            user = await _userManager.FindByEmailAsync(email);
            
            if (user is null)
            {
                isCreated = true;
                user = new User
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Active)
                };
                Console.WriteLine($"Callback user flag created email : {email}");
            }
        }
        else
        {
            user = await _userManager.FindByNameAsync(identifier);
        
            if (user is null)
            {
                isCreated = true;
                user = new User
                {
                    UserName = identifier,
                    EmailConfirmed = true,
                    Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Active)
                };
                
                Console.WriteLine($"Callback user flag created identifier : {identifier}");
            }
        }

        if (isCreated)
        {
            await _userManager.CreateAsync(user);
            
            //TODO: pending send to parameter role
            await _userManager.AddToRoleAsync(user, Enum.GetName(typeof(RoleEnum), RoleEnum.Guest)!);
        
            await _userManager.AddClaimsAsync(user, new List<Claim>
            {
                new(ClaimTypeConstant.FirstName, firstName ?? string.Empty, ClaimValueTypes.String),
                new(ClaimTypeConstant.LastName, lastName ?? string.Empty, ClaimValueTypes.String),
                new(ClaimTypeConstant.Avatar, GeneralConstant.DefaultAvatar, ClaimValueTypes.String)
            });
            
            Console.WriteLine($"Callback user created !!! : {identifier}");
            
            await _mediator.Publish(new ConfirmNotification{ UserId = user.Id.ToString() }, cancellationToken);
        }

        var identity = await _userManager.AddLoginAsync(user, info);
        
        await _signInManager.SignInAsync(user, false);

        return identity.Succeeded ? 
            Response.Ok(ResponseConstant.MessageSuccessConfirm, identity.Succeeded) : 
            Response.Fail(ResponseConstant.MessageFail, false);
    }
}
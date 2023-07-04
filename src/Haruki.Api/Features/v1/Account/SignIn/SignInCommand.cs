using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Interfaces;
using Haruki.Api.Domains.Entities;
using Haruki.Api.Features.v1.Account.Otp;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Haruki.Api.Features.v1.Account.SignIn;

public class SignInCommand : IRequest<ResponseBase<SignInResponse>>
{
    public SignInCommand(string userName, string password, bool rememberMe, string captcha, string returnUrl)
    {
        UserName = userName;
        Password = password;
        RememberMe = rememberMe;
        Captcha = captcha;
        ReturnUrl = returnUrl;
    }

    public string UserName { get; }

    public string Password { get;}

    public bool RememberMe { get; }

    public string Captcha { get; }

    public string ReturnUrl { get; }
}

public class SignInHandler : IRequestHandler<SignInCommand, ResponseBase<SignInResponse>>
{
    private readonly IMediator _mediator;
    private readonly ICaptchaService _captchaService;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IDateTimeService _dateTimeService;

    public SignInHandler(IMediator mediator, ICaptchaService captchaService, UserManager<User> userManager, SignInManager<User> signInManager, IDateTimeService dateTimeService)
    {
        _mediator = mediator;
        _captchaService = captchaService;
        _userManager = userManager;
        _signInManager = signInManager;
        _dateTimeService = dateTimeService;
    }
    
    public async Task<ResponseBase<SignInResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        //var isValid = await _captchaService.SiteVerify(request.Captcha);

        //if (!isValid)
            //return Response.Fail(ResponseConstant.MessageFail, new SignInResponse());

        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user is null)
            return Response.Fail(ResponseConstant.MessageFail, new SignInResponse());
            
        var result = await _signInManager.PasswordSignInAsync(user.UserName!, request.Password, request.RememberMe, true);
            
        if (result.IsNotAllowed)
            return Response.Fail(ResponseConstant.MessageConfirm, new SignInResponse());

        if (result.IsLockedOut)
        {
            await _mediator.Publish(new SignInNotification { UserName = user.UserName }, cancellationToken);
            return Response.Fail(ResponseConstant.MessageLockedAccount, new SignInResponse());
        }

        if (result.RequiresTwoFactor)
        {
            await _mediator.Publish(new OtpNotification { UserId = user.Id.ToString(), ReturnUrl = request.ReturnUrl }, cancellationToken);
            return Response.Ok(ResponseConstant.MessageSuccess, new SignInResponse { IsOtp = result.RequiresTwoFactor });
        }

        var claims = await _userManager.GetClaimsAsync(user);
        
        if(!claims.Any())
            return Response.Fail(ResponseConstant.MessageFail, new SignInResponse());
        
        var roles = await _userManager.GetRolesAsync(user);
        
        if(!roles.Any())
            Response.Fail(ResponseConstant.MessageFail, new SignInResponse());
        
        claims = new List<Claim>
        {
            new(ClaimTypes.Sid, user.Id.ToString()),
            new (ClaimTypes.Name, user.UserName),
            new (ClaimTypes.GivenName, $"Jose Oshiro")
        };
        
        claims.Add(new(ClaimTypes.Role, roles.ToList().FirstOrDefault()!));

        var securityToken = new JwtSecurityToken
        (
            issuer: SettingConstant.JwtIssuer,
            audience: SettingConstant.JwtAudience,
            claims: claims,
            expires: _dateTimeService.Now.AddHours(SettingConstant.JwtExpireIn),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SettingConstant.JwtSecret)),
                SecurityAlgorithms.HmacSha256Signature)
        );

        return result.Succeeded
            ? Response.Ok(ResponseConstant.MessageSuccess, new SignInResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken)
            })
            : Response.Fail(ResponseConstant.MessageFail, new SignInResponse());
    }
}
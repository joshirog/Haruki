using System.Text;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Dtos;
using Haruki.Api.Commons.Interfaces;
using Haruki.Api.Domains.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace Haruki.Api.Features.v1.Authentication.SignUp;

public class SignUpNotification : INotification
{
    public string UserName { get; init; }

    public string ReturnUrl { get; init; }  
}

 public class SignUpNotificationHandler : INotificationHandler<SignUpNotification>
{
    private readonly ICacheService _cacheService;
    private readonly INotificationService _notificationService;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<SignUpNotificationHandler> _logger;

    public SignUpNotificationHandler(ICacheService cacheService, INotificationService notificationService, UserManager<User> userManager, ILogger<SignUpNotificationHandler> logger)
    {
        _cacheService = cacheService;
        _notificationService = notificationService;
        _userManager = userManager;
        _logger = logger;
    }
    
    public async Task Handle(SignUpNotification notification, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(notification.UserName);

        if (user is null)
            throw new Exception($"SignUpNotificationHandler user {notification.UserName} not exist");
            
        var claims = await _userManager.GetClaimsAsync(user);
        
        var firstname = claims.Where(x => x.Type.Equals(ClaimTypeConstant.FirstName)).Select(x => x.Value).FirstOrDefault();

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var tokenEncodedBytes = Encoding.UTF8.GetBytes(token);
        var tokenEncoded = WebEncoders.Base64UrlEncode(tokenEncodedBytes);
    
        var link = $"{SettingConstant.WebUrl}/{SettingConstant.WebRouteConfirm}/{user.Id}?token={tokenEncoded}&returnUrl={notification.ReturnUrl}";
    
        _logger.LogInformation("SignUpNotificationHandler active account link : {Link}", link);

        var html = _cacheService.Template(TemplateConstant.TemplateActivation);
        html = html.Replace("{0}", firstname);
        html = html.Replace("{1}", link);
        
        var emailId = await _notificationService.SendEmail(new EmailDto
        {
            Sender = new SenderDto { Id = TemplateConstant.SenderId },
            To = new List<ToDto> { new() { Name = firstname, Email = user.Email } },
            Subject = TemplateConstant.SubjectActivateAccount,
            HtmlContent = html,
            TextContent = TemplateConstant.SubjectActivateAccount
        });
        
        _logger.LogInformation("SignUpNotificationHandler email id : {EmailId}", emailId);
    }
}
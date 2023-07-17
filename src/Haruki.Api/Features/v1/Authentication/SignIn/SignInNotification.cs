using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Dtos;
using Haruki.Api.Commons.Interfaces;
using Haruki.Api.Domains.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Features.v1.Authentication.SignIn;

public class SignInNotification : INotification
{
    public string UserName { get; init; }
}

public class SignInNotificationHandler : INotificationHandler<SignInNotification>
{
    private readonly ICacheService _cacheService;
    private readonly INotificationService _notificationService;
    private readonly UserManager<User> _userManager;

    public SignInNotificationHandler(ICacheService cacheService, INotificationService notificationService, UserManager<User> userManager)
    {
        _cacheService = cacheService;
        _notificationService = notificationService;
        _userManager = userManager;
    }
    
    public async Task Handle(SignInNotification notification, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(notification.UserName);

        if (user is null)
            throw new Exception($"User {notification.UserName} not exist");
        
        var claims = await _userManager.GetClaimsAsync(user);

        if (!string.IsNullOrEmpty(user.Email))
        {
            var firstName = claims.Where(x => x.Type.Equals(ClaimTypeConstant.FirstName)).Select(x => x.Value).FirstOrDefault();
            
            var html = _cacheService.Template(TemplateConstant.TemplateLocked);
            html = html.Replace("{0}", SettingConstant.WebUrl);

            await _notificationService.SendEmail(new EmailDto
            {
                Sender = new SenderDto { Id = TemplateConstant.SenderId },
                To = new List<ToDto> { new() { Name = firstName, Email = user.Email } },
                Subject = TemplateConstant.SubjectLockedAccount,
                HtmlContent = html,
                TextContent = TemplateConstant.SubjectLockedAccount
            });
        }
    }
}
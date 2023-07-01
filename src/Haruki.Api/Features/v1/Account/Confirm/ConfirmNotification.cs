using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Dtos;
using Haruki.Api.Commons.Interfaces;
using Haruki.Api.Domains.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Features.v1.Account.Confirm;

public class ConfirmNotification : INotification
{
    public string UserId { get; init; }
}

public class ConfirmNotificationHandler : INotificationHandler<ConfirmNotification>
{
    private readonly ICacheService _cacheService;
    private readonly INotificationService _notificationService;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<ConfirmNotificationHandler> _logger;

    public ConfirmNotificationHandler(ICacheService cacheService, INotificationService notificationService, UserManager<User> userManager, ILogger<ConfirmNotificationHandler> logger)
    {
        _cacheService = cacheService;
        _notificationService = notificationService;
        _userManager = userManager;
        _logger = logger;
    }

    public async Task Handle(ConfirmNotification notification, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(notification.UserId);

        if (user is null)
            throw new Exception($"User {notification.UserId} not exist");
        
        var claims = await _userManager.GetClaimsAsync(user);
        var firstName = claims.Where(x => x.Type.Equals(ClaimTypeConstant.FirstName)).Select(x => x.Value).FirstOrDefault();

        var html = _cacheService.Template(TemplateConstant.TemplateWelcome);
        html = html.Replace("{0}", firstName);
        html = html.Replace("{1}", SettingConstant.WebUrl);
        
        var emailId = await _notificationService.SendEmail(new EmailDto
        {
            Sender = new SenderDto { Id = TemplateConstant.SenderId },
            To = new List<ToDto> { new() { Name = firstName, Email = user.Email } },
            Subject = TemplateConstant.SubjectWelcome,
            HtmlContent = html,
            TextContent =  TemplateConstant.SubjectWelcome,
        });
        
        _logger.LogInformation("ConfirmNotificationHandler email id : {EmailId}", emailId);
    }
}
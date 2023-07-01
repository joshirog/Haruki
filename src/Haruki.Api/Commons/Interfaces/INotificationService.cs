using Haruki.Api.Commons.Dtos;

namespace Haruki.Api.Commons.Interfaces;

public interface INotificationService
{
    Task<string> SendEmail(EmailDto entity);
}
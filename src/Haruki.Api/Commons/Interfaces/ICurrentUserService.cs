namespace Haruki.Api.Commons.Interfaces;

public interface ICurrentUserService
{
    string UserId { get; }

    string UserName { get; }
}
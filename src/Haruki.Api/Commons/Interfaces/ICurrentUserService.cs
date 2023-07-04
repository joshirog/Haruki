namespace Haruki.Api.Commons.Interfaces;

public interface ICurrentUserService
{
    bool IsAuthenticated { get; }

    string UserId { get; }

    string UserName { get; }

    string Role { get; }

    string Token { get; }
}
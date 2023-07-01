namespace Haruki.Api.Features.v1.Account.SignIn;

public class SignInResponse
{
    public bool IsOtp { get; set; }

    public string Token { get; set; }
}
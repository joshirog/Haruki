namespace Haruki.Api.Features.v1.Account.SignUp;

public class SignUpCommand
{
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public string UserName { get; init; }
    
    public string Password { get; init; }
    
    public string Email { get; init; }
    
    public string PhoneNumber { get; init; }
}
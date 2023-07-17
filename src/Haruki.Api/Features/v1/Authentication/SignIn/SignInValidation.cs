using FluentValidation;

namespace Haruki.Api.Features.v1.Authentication.SignIn;

public class SignInValidator : AbstractValidator<SignInCommand>
{
    public SignInValidator()
    {
        RuleFor(v => v.UserName)
            .MaximumLength(200)
            .NotEmpty()
            .EmailAddress();
            
        RuleFor(v => v.Password)
            .MaximumLength(200)
            .NotEmpty();
    }
}
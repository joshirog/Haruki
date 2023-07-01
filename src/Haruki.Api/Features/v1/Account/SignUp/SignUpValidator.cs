using FluentValidation;

namespace Haruki.Api.Features.v1.Account.SignUp;

public class SignUpValidator : AbstractValidator<SignUpCommand>
{
    public SignUpValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(100)
            .NotEmpty();
            
        RuleFor(v => v.LastName)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.PhoneNumber)
            .MaximumLength(12)
            .NotEmpty();
            
        RuleFor(v => v.Email)
            .MaximumLength(200)
            .NotEmpty()
            .EmailAddress();

        RuleFor(v => v.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(100)
            .Equal(x => x.ConfirmPassword)
            .WithMessage("The password entered must be the same as the confirmed password.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,}$").WithMessage(
                "The password is insecure, please try entering a new one. It must contain at least one lowercase letter, one uppercase letter, numbers, and at least one special character.");
    }
}
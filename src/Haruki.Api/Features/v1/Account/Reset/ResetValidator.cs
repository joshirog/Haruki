using FluentValidation;

namespace Haruki.Api.Features.v1.Account.Reset;

public class ResetValidator : AbstractValidator<ResetCommand>
{
    public ResetValidator()
    {
        RuleFor(v => v.UserId)
            .MaximumLength(36)
            .NotEmpty();
            
        RuleFor(v => v.Token)
            .NotEmpty();
            
        RuleFor(v => v.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(100)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,}$").WithMessage("The password is insecure, please try entering a new one. It must contain at least one lowercase letter, one uppercase letter, numbers, and at least one special character.");
            
        RuleFor(v => v.Password)
            .Equal(v => v.ConfirmPassword).WithMessage("The password entered must be the same as the confirmed password.");
    }
}
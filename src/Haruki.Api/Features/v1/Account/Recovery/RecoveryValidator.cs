using FluentValidation;

namespace Haruki.Api.Features.v1.Account.Recovery;

public class RecoveryValidator : AbstractValidator<RecoveryCommand>
{
    public RecoveryValidator()
    {
        RuleFor(v => v.Email)
            .EmailAddress()
            .NotEmpty();
    }
}
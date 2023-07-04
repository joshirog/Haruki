using FluentValidation;

namespace Haruki.Api.Features.v1.Account.Otp;

public class OtpValidator : AbstractValidator<OtpCommand>
{
    public OtpValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty();
    }
}
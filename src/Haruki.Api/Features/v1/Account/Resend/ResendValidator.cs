using FluentValidation;
using Haruki.Api.Commons.Bases;
using MediatR;

namespace Haruki.Api.Features.v1.Account.Resend;

public class ResendValidator : AbstractValidator<ResendCommand>
{
    public ResendValidator()
    {
        RuleFor(v => v.UserId)
            .MaximumLength(36)
            .NotEmpty();
    }
}
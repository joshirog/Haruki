using FluentValidation.Results;

namespace Haruki.Api.Commons.Exceptions;

public class ValidationsException : Exception
{
    public ValidationsException() : base("One or more validation failures have occurred.")
    {
        Errors = new List<ValidationFailure>();
    }

    public ValidationsException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures;
    }

    public IEnumerable<ValidationFailure> Errors { get; }
}

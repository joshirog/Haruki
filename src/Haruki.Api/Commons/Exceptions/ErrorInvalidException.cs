namespace Haruki.Api.Commons.Exceptions;

public class ErrorInvalidException : Exception
{
    public IEnumerable<string> Errors { get; }
        
    public ErrorInvalidException(IEnumerable<string> errors)
    {
        Errors = errors;
    }
}
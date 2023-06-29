namespace Haruki.Api.Commons.Bases;

public static class Response
{
    public static ResponseBase<T> Ok<T>(string message, T data = default!) => new(data, message ?? "Success", true);

    public static ResponseBase<T> Fail<T>(string message, T data = default!) => new(data, message, false);

    public static ResponseBase<T> Error<T>(string exception, IEnumerable<string> errors) => new(exception, errors);

    public static ResponseBase<T> Exception<T>(string exception) => new(exception);
}

public class ResponseBase<T>
{
    public ResponseBase(T data, string message, bool success)
    {
        Message = message;
        Data = data;
        Success = success;
    }

    public ResponseBase(string exception = null, IEnumerable<string> errors = null)
    {
        Success = false;
        Exception = exception;
        Errors = errors;
    }

    public bool Success { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public string Exception { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
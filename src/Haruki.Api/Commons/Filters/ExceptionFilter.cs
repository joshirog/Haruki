using AutoMapper;
using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Haruki.Api.Commons.Filters;


public class ExceptionFilter : ExceptionFilterAttribute
{
    private readonly IDictionary<string, Action<ExceptionContext>> _exceptionHandlers;

    private string CustomMessage = "";

    private readonly IEnumerable<string> CustomErrors;

    private IEnumerable<string> CustomValidationMessage;

    public ExceptionFilter(IEnumerable<string> customErrors, IEnumerable<string> customValidationMessage)
    {
        CustomErrors = customErrors;
        CustomValidationMessage = customValidationMessage;

        _exceptionHandlers = new Dictionary<string, Action<ExceptionContext>>
        {
            { nameof(ValidationsException), HandleValidationException },
            { nameof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
            { nameof(AutoMapperMappingException), HandleAutoMapperMappingException },
        };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        if (CustomValidationMessage is null)
            context.Result = new JsonResult(Response.Error<object>(CustomMessage, CustomValidationMessage));
        else
        {
            context.Result = CustomValidationMessage.Any()
                ? new JsonResult(Response.Error<object>(CustomMessage, CustomValidationMessage))
                : new JsonResult(Response.Fail<object>(CustomErrors.FirstOrDefault()));
        }

        base.OnException(context);
    }

    private void HandleAutoMapperMappingException(ExceptionContext context)
    {
        var exception = context.Exception as AutoMapperMappingException;

        CustomMessage = exception?.Message;

        context.ExceptionHandled = true;
    }

    private void HandleException(ExceptionContext context)
    {
        var type = context.Exception.GetType().Name;
        if (_exceptionHandlers.TryGetValue(type, out var handler))
        {
            handler.Invoke(context);
            return;
        }

        HandleUnknownException(context);
    }

    private void HandleValidationException(ExceptionContext context)
    {
        var exception = context.Exception as ValidationsException;

        CustomValidationMessage = (from error in exception?.Errors select error.ErrorMessage).ToList();

        context.ExceptionHandled = true;
    }

    private void HandleUnauthorizedAccessException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Title = "Unauthorized",
            Type = "https://tools.ietf.org/html/rfc7235#section-3.1"
        };

        CustomMessage = "Error " + details.Status + ": " + details.Title;

        context.ExceptionHandled = true;
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        CustomMessage = $"{context.Exception.Message} {context.Exception.InnerException}";

        context.ExceptionHandled = true;
    }
}
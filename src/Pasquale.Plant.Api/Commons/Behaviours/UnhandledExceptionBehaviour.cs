using System.Reflection;
using MediatR;

namespace Pasquale.Plant.Api.Commons.Behaviours;


public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var responseName = typeof(TResponse).Name;
        var projectName = Assembly.GetEntryAssembly()?.GetName().Name;
        
        try
        {
            _logger.LogInformation("{ProjectName} Start: {Name} {@Request}", projectName, requestName, request);
            
            return await next();
        }
        catch (Exception ex)
        {
            if (ex.GetType().IsAssignableFrom(typeof(UnauthorizedAccessException)))
            {
                _logger.LogWarning(ex, "{ProjectName} Request: Unhandled Exception for Request {Name} {@Request}", projectName, requestName, request);
            }
            else
            {
                _logger.LogError(ex, "{ProjectName} Request: Unhandled Exception for Request {Name} {@Request}", projectName, requestName, request);
            }

            throw;
        }
        finally
        {
            _logger.LogInformation("{ProjectName} Finally: {RequestName} {@Request} {ResponseName}", projectName, requestName, request, responseName);
        }
    }
}

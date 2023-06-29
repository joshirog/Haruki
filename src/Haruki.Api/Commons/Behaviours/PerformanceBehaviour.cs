using System.Diagnostics;
using System.Reflection;
using Haruki.Api.Commons.Interfaces;
using MediatR;

namespace Haruki.Api.Commons.Behaviours;


public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentUserService _currentUserService;

    public PerformanceBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _timer = new Stopwatch();
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds <= 500) 
            return response;
        
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId;

        _logger.LogWarning("{ProjectName} Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}", Assembly.GetEntryAssembly()?.GetName().Name, requestName, elapsedMilliseconds, userId, request);

        return response;
    }
}

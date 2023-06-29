using System.Reflection;
using Haruki.Api.Commons.Interfaces;
using MediatR.Pipeline;

namespace Haruki.Api.Commons.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentUserService _currentUserService;
    private readonly IJsonSerializerService _jsonSerializerService;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService, IJsonSerializerService jsonSerializerService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
        _jsonSerializerService = jsonSerializerService;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId;
        var jrequest = _jsonSerializerService.Serialize(request);

        return Task.Run(() => _logger.LogInformation("{ProjectName} Request: {Name} - user {@UserId} {@Request1} {@Request2}", Assembly.GetEntryAssembly()?.GetName().Name, requestName, userId, request, jrequest), cancellationToken);
    }
}
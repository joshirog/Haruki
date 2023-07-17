using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Haruki.Api.Features.v1.Authentication.External;

public class ExternalQuery : IRequest<ResponseBase<List<AuthenticationScheme>>>
{ 
    
}

public class ExternalQueryHandler : IRequestHandler<ExternalQuery, ResponseBase<List<AuthenticationScheme>>>
{
    private readonly ICacheService _cacheService;

    public ExternalQueryHandler(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<ResponseBase<List<AuthenticationScheme>>> Handle(ExternalQuery request, CancellationToken cancellationToken)
    {
        var schemes = await _cacheService.ExternalLogin();
        
        return schemes.Any() ? 
            Response.Ok(ResponseConstant.MessageSuccess, schemes) : 
            Response.Fail(ResponseConstant.MessageFail, new List<AuthenticationScheme>());
    }
}
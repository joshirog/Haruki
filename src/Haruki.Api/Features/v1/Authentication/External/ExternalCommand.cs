using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Domains.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Features.v1.Authentication.External;

public class ExternalCommand : IRequest<ResponseBase<AuthenticationProperties>>
{
    public string Provider { get; set; }

    public string ReturnUrl { get; set; }
}

public class ExternalCommandHandler : IRequestHandler<ExternalCommand, ResponseBase<AuthenticationProperties>>
{
    private readonly SignInManager<User> _signInManager;

    public ExternalCommandHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<ResponseBase<AuthenticationProperties>> Handle(ExternalCommand request, CancellationToken cancellationToken)
    {
        var redirectUrl = $"{SettingConstant.WebUrl}/{SettingConstant.WebRouteExternal}{request.ReturnUrl}";
        
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(request.Provider, redirectUrl);

        await Task.CompletedTask;
        
        return properties.Parameters.Any() ? 
            Response.Ok(ResponseConstant.MessageSuccess, properties) : 
            Response.Fail(ResponseConstant.MessageFail, new AuthenticationProperties());
    }
}
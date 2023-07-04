using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Account.External;

public class CallbackController : ApiControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "External callback authentication login", Description = "External callback authentication login")]
    public async Task<IActionResult> Callback(CallbackCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
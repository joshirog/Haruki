using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Account.Resend;

public class ResendController : ApiControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Resend change password account", Description = "Resend change password account")]
    public async Task<IActionResult> Resend([FromBody] ResendCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpGet]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Resend change password account", Description = "Resend change password account")]
    public async Task<IActionResult> Resend(string userId)
    {
        return Ok(await Mediator.Send(new ResendCommand(userId)));
    }
}
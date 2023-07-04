using Haruki.Api.Commons.Bases;
using Haruki.Api.Features.v1.Account.Resend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Account.Reset;

public class ResetController : ApiControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Reset a new password account", Description = "Reset a new password account")]
    public async Task<IActionResult> Reset([FromBody] ResetCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpGet]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Reset a new password account", Description = "Reset a new password account")]
    public async Task<IActionResult> Reset(string userId, string token)
    {
        return Ok(await Mediator.Send(new ResetCommand(userId, token)));
    }
}
using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Account.Recovery;

public class RecoveryController : ApiControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Recovery password account", Description = "Recovery password account")]
    public async Task<IActionResult> Recovery([FromBody] RecoveryCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
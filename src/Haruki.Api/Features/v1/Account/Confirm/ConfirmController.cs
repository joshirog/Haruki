using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Account.Confirm;

public class ConfirmController : ApiControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Confirm activate account", Description = "Confirm activate account")]
    public async Task<IActionResult> Confirm([FromBody] ConfirmCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
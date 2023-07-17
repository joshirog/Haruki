using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Authentication.Confirm;

public class ConfirmController : ApiControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Authentication")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Confirm activate account", Description = "Confirm activate account")]
    public async Task<IActionResult> Confirm([FromBody] ConfirmCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Authentication.Otp;

public class OtpController : ApiControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Authentication")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Otp 2 factor authentication", Description = "Otp 2 factor authentication")]
    public async Task<IActionResult> Otp([FromBody] OtpCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
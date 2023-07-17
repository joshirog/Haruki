using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Authentication.External;

public class ExternalController : ApiControllerBase
{
    [HttpPost]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Authentication")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "External authentication login", Description = "External authentication login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> External([FromBody] ExternalCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpGet]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Authentication")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "External schemes authentication login", Description = "External schemes authentication login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> External()
    {
        return Ok(await Mediator.Send(new ExternalQuery()));
    }
}
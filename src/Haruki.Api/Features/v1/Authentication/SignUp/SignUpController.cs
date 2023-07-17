using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Authentication.SignUp;

public class SignUpController : ApiControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Authentication")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Create new user", Description = "Create new user")]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
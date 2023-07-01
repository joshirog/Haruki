using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Account.SignIn;

public class SignInController : ApiControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Authentication user", Description = "Authentication user")]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
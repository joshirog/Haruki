using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Account.SignOut;

public class SignOutController : ApiControllerBase
{
    [HttpPost]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Sign out account session", Description = "Sign out account session")]
    public async Task<IActionResult> SignOut([FromBody] SignOutCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
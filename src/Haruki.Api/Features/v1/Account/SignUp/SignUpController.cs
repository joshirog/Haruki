using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Account.SignUp;

public class SignUpController : ApiControllerBase
{
    [HttpPost]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Return task", Description = "Create a task")]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
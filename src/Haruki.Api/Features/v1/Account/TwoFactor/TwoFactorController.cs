using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Account.TwoFactor;

public class TwoFactorController : ApiControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Two step authenticator 2Factor", Description = "Two step authenticator 2Factor")]
    public async Task<IActionResult> TwoStep([FromBody] TwoFactorCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpGet]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Two step authenticator 2Factor", Description = "Two step authenticator 2Factor")]
    public async Task<IActionResult> TwoStep(Guid userId)
    {
        return Ok(await Mediator.Send(new TwoFactorCommand(userId)));
    }
}
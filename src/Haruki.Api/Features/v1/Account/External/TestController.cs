using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Account.External;

public class TestController : ApiControllerBase
{
    [HttpGet]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Test", Description = "Test")]
    public async Task<IActionResult> Test()
    {
        await Task.CompletedTask;
        return Ok(Commons.Bases.Response.Ok(ResponseConstant.MessageSuccess, new [] {"Jose Oshiro", "Ricardo Oshiro", "Miguel Oshiro"}));
    }
}
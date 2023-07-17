using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Haruki.Api.Features.v1.Services.GetServices;

public class GetServicesController : ApiControllerBase
{
    [AllowAnonymous]
    [HttpGet("/api/v{version:apiVersion}/categories")]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Categories")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Get all categories", Description = "Get all categories")]
    public async Task<IActionResult> GetCategories()
    {
        return Ok(await Mediator.Send(new GetServicesQuery()));
    }
}
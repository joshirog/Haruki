using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Haruki.Api.Commons.Bases;

[ApiController]
[Route( "api/v{version:apiVersion}/[controller]" )]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>()!;
}
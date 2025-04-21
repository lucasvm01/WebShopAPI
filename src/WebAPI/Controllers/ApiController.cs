using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebShopAPI.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
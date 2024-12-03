using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_System_Server.WebAPI.Abstractions;
[Route("Api/[controller]/[action]")]
[ApiController]

public abstract class ApiController : ControllerBase
{
    public readonly IMediator _mediator;

    protected ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
using Appointment_System_Server.Application.Features.Auth.Login;
using Appointment_System_Server.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_System_Server.WebAPI.Controllers;

public sealed class AuthController : ApiController
{
    private AuthController(IMediator mediator) : base(mediator)
    {
    }

    

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
        
}
using Appointment_System_Server.Application.Features.Doctors.CreateDoctor;
using Appointment_System_Server.Application.Features.Doctors.DeleteDoctorById;
using Appointment_System_Server.Application.Features.Doctors.GetAllDoctors;
using Appointment_System_Server.Application.Features.Doctors.UpadateDoctor;
using Appointment_System_Server.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_System_Server.WebAPI.Controllers;

public sealed class DoctorsController : ApiController
{
    public DoctorsController(IMediator mediator) : base(mediator) { }
    
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllDoctorQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateDoctor(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
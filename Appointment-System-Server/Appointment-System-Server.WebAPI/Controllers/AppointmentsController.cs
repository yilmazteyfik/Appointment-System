using Appointment_System_Server.Application.Features.Appointments.CreateAppointment;
using Appointment_System_Server.Application.Features.Appointments.GetAllAppointmentsByDoctorId;
using Appointment_System_Server.Application.Features.Appointments.GetAllDoctorByDepartment;
using Appointment_System_Server.Application.Features.Appointments.GetPatientByIdentityNumber;
using Appointment_System_Server.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_System_Server.WebAPI.Controllers;

public sealed class AppointmentsController : ApiController
{
    public AppointmentsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAllDoctorByeDepartment(
        GetAllDoctorByeDepartmentQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPost]
    public async Task<IActionResult> GetAllByDoctorId(
        GetAllAppointmentsByDoctorIdQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPost]
    public async Task<IActionResult> GetPatientByIdentityNumber(
        GetPatientByIdentityNumberQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
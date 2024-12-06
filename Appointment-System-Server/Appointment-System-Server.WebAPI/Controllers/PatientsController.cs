
using Appointment_System_Server.Application.Features.Patients.CreatePatients;
using Appointment_System_Server.Application.Features.Patients.DeletePatientById;
using Appointment_System_Server.Application.Features.Patients.GetAllPatients;
using Appointment_System_Server.Application.Features.Patients.UpdatePatient;
using Appointment_System_Server.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_System_Server.WebAPI.Controllers;

public sealed class PatientsController : ApiController
{
    public PatientsController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteById(DeletePatientByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> UpdatePatient(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
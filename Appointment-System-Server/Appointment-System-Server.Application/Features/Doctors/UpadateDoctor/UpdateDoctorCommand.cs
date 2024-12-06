using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Doctors.UpadateDoctor;

public sealed record UpdateDoctorCommand( 
    Guid Id,
    string FirstName,
    string LastName,
    int DepartmentValue): IRequest<Result<string>>;
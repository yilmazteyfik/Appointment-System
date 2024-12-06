using Appointment_System_Server.Domain.Enums;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Doctors.CreateDoctor;

public sealed record CreateDoctorCommand(
    string FirstName,
    string LastName,
    int DepartmentValue) : IRequest<Result<string>>;
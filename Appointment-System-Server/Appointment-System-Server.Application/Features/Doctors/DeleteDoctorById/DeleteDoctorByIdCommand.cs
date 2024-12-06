using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Doctors.DeleteDoctorById;

public sealed record DeleteDoctorByIdCommand(
    Guid Id): IRequest<Result<string>>;
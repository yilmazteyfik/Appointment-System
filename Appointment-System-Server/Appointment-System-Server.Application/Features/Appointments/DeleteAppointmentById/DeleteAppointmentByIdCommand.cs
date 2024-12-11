using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Appointments.DeleteAppointmentById;

public sealed record DeleteAppointmentByIdCommand(
    Guid Id): IRequest<Result<string>>;
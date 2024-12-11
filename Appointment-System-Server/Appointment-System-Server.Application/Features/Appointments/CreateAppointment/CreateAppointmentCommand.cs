using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Appointments.CreateAppointment;

public sealed record CreateAppointmentCommand(
    Guid? PatientId,
    Guid DoctorId,
    string StartDate,
    string EndDate,
    string FirstName,
    string LastName,
    string IdentityNumber,
    string City,
    string Town,
    string FullAddress): IRequest<Result<string>>;
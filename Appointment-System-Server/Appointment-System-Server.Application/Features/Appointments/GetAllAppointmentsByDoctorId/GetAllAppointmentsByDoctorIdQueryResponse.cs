using Appointment_System_Server.Domain.Entities;

namespace Appointment_System_Server.Application.Features.Appointments.GetAllAppointmentsByDoctorId;

public sealed record GetAllAppointmentsByDoctorIdQueryResponse(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    string Title,
    Patient Patient);
using Appointment_System_Server.Application.Features.Appointments.GetAllAppointmentsByDoctorId;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Appointments.GetAllAppointmentsByDoctorId;

public sealed record GetAllAppointmentsByDoctorIdQuery(Guid DoctorId)
    : IRequest<Result<List<GetAllAppointmentsByDoctorIdQueryResponse>>>;
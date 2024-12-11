using Appointment_System_Server.Domain.Entities;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Appointments.GetPatientByIdentityNumber;

public sealed record GetPatientByIdentityNumberQuery(
    string IdentityNumber) : IRequest<Result<Patient>>;
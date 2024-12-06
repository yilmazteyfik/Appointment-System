using Appointment_System_Server.Domain.Entities;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Patients.GetAllPatients;

public sealed record GetAllPatientsQuery() : IRequest<Result<List<Patient>>>;
using AutoMapper;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Patients.DeletePatientById;

public sealed record DeletePatientByIdCommand(Guid Id) : IRequest<Result<string>>;
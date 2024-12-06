using Appointment_System_Server.Domain.Entities;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Doctors.GetAllDoctors;

public sealed record GetAllDoctorQuery() : IRequest<Result<List<Doctor>>>;
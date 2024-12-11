using Appointment_System_Server.Domain.Entities;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Appointments.GetAllDoctorByDepartment;

public sealed record GetAllDoctorByeDepartmentQuery(
    int DepartmentValue) : IRequest<Result<List<Doctor>>>;
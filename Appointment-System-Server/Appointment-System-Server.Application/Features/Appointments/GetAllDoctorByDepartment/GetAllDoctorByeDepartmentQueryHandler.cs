using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Appointments.GetAllDoctorByDepartment;

internal sealed class
    GetAllDoctorByeDepartmentQueryHandler(
        IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorByeDepartmentQuery, 
    Result<List<Doctor>>>
{
    public async Task<Result<List<Doctor>>> Handle(
        GetAllDoctorByeDepartmentQuery request, CancellationToken cancellationToken)
    {
        List<Doctor> doctors = await doctorRepository
            .Where(p => p.Department == request.DepartmentValue)
            .OrderBy(p => p.FirstName)
            .ToListAsync(cancellationToken);
        return doctors;
    }
}
using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Patients.GetAllPatients;

internal sealed class GetAllPatientsQueryHandler(IPatientRepository patientRepository)
    : IRequestHandler<GetAllPatientsQuery, Result<List<Patient>>>
{
    public async Task<Result<List<Patient>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        List<Patient> patients = await patientRepository
            .GetAll()
            .OrderBy(p => p.FirstName)
            .ToListAsync(cancellationToken);
        return patients;
    }
}
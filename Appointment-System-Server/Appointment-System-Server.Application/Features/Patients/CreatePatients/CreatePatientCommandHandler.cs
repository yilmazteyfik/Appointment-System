using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using AutoMapper;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Patients.CreatePatients;

internal sealed class CreatePatientCommandHandler(
    IPatientRepository patientRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreatePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        if (patientRepository.Any(p => p.IdentityNumber == request.IdentityNumber))
        {
            return Result<string>.Failure("Patient already recorded");
        }
        
            
            
        Patient patient = mapper.Map<Patient>(request);
        if (patient.IdentityNumber != request.IdentityNumber ) {
            if (patientRepository.Any(p=> p.IdentityNumber == request.IdentityNumber)) {
                return Result<string>.Failure("This Identity Number is Already using");
            }
        }
        await patientRepository.AddAsync(patient, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Patients creation is Successful";
    }
   
}
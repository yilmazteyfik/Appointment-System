using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using AutoMapper;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Patients.UpdatePatient;

public sealed class UpdatePatientCommandHandler(
    IPatientRepository patientRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdatePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        Patient? patient = await patientRepository.GetByExpressionWithTrackingAsync(p =>
            p.Id == request.Id, cancellationToken);
        if (patient is null) {
            return Result<string>.Failure("Patient is not found!");
        }

        if (patient.IdentityNumber != request.IdentityNumber ) {
            if (patientRepository.Any(p=> p.IdentityNumber == request.IdentityNumber)) {
                return Result<string>.Failure("This Identity Number is Already using");
            }
        }
        mapper.Map(request, patient);
        patientRepository.Update(patient);
        await unitOfWork.SaveChangesAsync();
        return "Patient Update is Successful";


    }
}
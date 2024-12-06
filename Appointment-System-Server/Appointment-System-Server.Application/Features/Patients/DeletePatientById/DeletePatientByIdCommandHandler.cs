using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Patients.DeletePatientById;

internal sealed class DeletePatientByIdCommandHandler(
    IPatientRepository patientRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeletePatientByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeletePatientByIdCommand request, CancellationToken cancellationToken)
    {
        Patient? patient = await patientRepository.GetByExpressionAsync(
            p => p.Id == request.Id, cancellationToken);
        if (patient is null) {
            return Result<string>.Failure("Patient is not found!");
            
        }
        patientRepository.Delete(patient);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Patiend Delete is Successful";
    }
}
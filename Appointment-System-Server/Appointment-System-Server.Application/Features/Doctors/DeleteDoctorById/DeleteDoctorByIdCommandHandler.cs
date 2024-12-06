using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Doctors.DeleteDoctorById;

internal sealed class DeleteDoctorByIdCommandHandler(
    IDoctorRepository doctorRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteDoctorByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
    {
        Doctor? doctor =await doctorRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (doctor is null)
        {
            return Result<String>.Failure("Doctor not found!");
        }

        doctorRepository.Delete(doctor);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Doctor Delete is Successful";
    }
}
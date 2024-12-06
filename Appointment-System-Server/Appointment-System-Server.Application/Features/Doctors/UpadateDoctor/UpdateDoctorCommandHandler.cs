using Appointment_System_Server.Application.Features.Doctors.DeleteDoctorById;
using Appointment_System_Server.Application.Features.Patients.UpdatePatient;
using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using AutoMapper;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Doctors.UpadateDoctor;

internal sealed class UpdateDoctorCommandHandler(
    IDoctorRepository doctorRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateDoctorCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        Doctor? doctor =await doctorRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
        if (doctor is null) {
            return Result<String>.Failure("Doctor not found!");
        }
       

        mapper.Map(request, doctor);
        doctorRepository.Update(doctor);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Doctor Update is Successful";
    }
} 
using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using AutoMapper;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Doctors.CreateDoctor;

internal sealed class CreateDoctorCommandHandler(
    IDoctorRepository doctorRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateDoctorCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        Doctor doctor = mapper.Map<Doctor>(request);
        await doctorRepository.AddAsync(doctor, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Doctor creation is succesfull";
    }
}
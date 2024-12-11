using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Appointments.CreateAppointment;

internal sealed class CreateAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    IPatientRepository patientRepository,
    IUnitOfWork unitOfWork) : 
    IRequestHandler<CreateAppointmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        DateTime startDate = DateTime.SpecifyKind(DateTime.ParseExact(request.StartDate, "dd.MM.yyyy HH:mm", null),
            DateTimeKind.Utc);
        DateTime endDate = DateTime.SpecifyKind(DateTime.ParseExact(request.EndDate, "dd.MM.yyyy HH:mm", null),
            DateTimeKind.Utc);
        Patient patient = new Patient();
        if (request.PatientId is null)
        {
            patient = new Patient()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdentityNumber = request.IdentityNumber,
                City = request.City,
                Town = request.Town,
                FullAddress = request.FullAddress
                
            };
            await patientRepository.AddAsync(patient, cancellationToken);
        }

        bool isAppointmentDateNotAvailable = await appointmentRepository
            .AnyAsync(p=>p.DoctorId == request.DoctorId &&
                         ((p.StartDate < endDate && p.StartDate >= startDate) ||
                          (p.EndDate > startDate && p.EndDate < endDate)      ||
                          (p.StartDate >= startDate && p.EndDate <= endDate)  ||
                          (p.StartDate <= startDate && p.EndDate >= endDate)), cancellationToken);
        if (isAppointmentDateNotAvailable)
        {
            return Result<string>.Failure("This appointment date is not available!");
        }
        
        Appointment appointment = new Appointment()
        {
            DoctorId = request.DoctorId,
            PatientId = request.PatientId ?? patient.Id,
            StartDate = startDate,
            EndDate = endDate,
            IsCompleted = false
        };
        
        
        
        
        
        await appointmentRepository.AddAsync(appointment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Appointment creation is successful";

    }
}
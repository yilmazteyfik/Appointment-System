using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Appointments.UpdateAppointment;

internal sealed class UpdateAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateAppointmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        DateTime startDate = DateTime.SpecifyKind(DateTime.ParseExact(request.StartDate, "dd.MM.yyyy HH:mm", null),
            DateTimeKind.Utc);
        DateTime endDate = DateTime.SpecifyKind(DateTime.ParseExact(request.EndDate, "dd.MM.yyyy HH:mm", null),
            DateTimeKind.Utc);
        Appointment? appointment = await appointmentRepository.GetByExpressionWithTrackingAsync(p => p.Id ==
            request.Id, cancellationToken);
        if (appointment is null)
        {
            return Result<string>.Failure("Appointment not found!");
        }

        bool isAppointmentDateNotAvailable = await appointmentRepository
            .AnyAsync(p=>p.DoctorId == appointment.DoctorId &&
                         ((p.StartDate < endDate && p.StartDate >= startDate) ||
                          (p.EndDate > startDate && p.EndDate < endDate)      ||
                          (p.StartDate >= startDate && p.EndDate <= endDate)  ||
                          (p.StartDate <= startDate && p.EndDate >= endDate)), cancellationToken);
        if (isAppointmentDateNotAvailable)
        {
            return Result<string>.Failure("This appointment date is not available!");
        }
        appointment.StartDate = startDate;
        appointment.EndDate = endDate;

    
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Appointment update is successful";

    }
}
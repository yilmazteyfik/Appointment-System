using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Appointments.DeleteAppointmentById;

internal sealed class DeleteAppointmentByIdCommandHandler(
    IAppointmentRepository appointmentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteAppointmentByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteAppointmentByIdCommand request,
        CancellationToken cancellationToken)
    {
        Appointment? appointment = await appointmentRepository.GetByExpressionAsync(p => p.Id ==
            request.Id, cancellationToken);
        if (appointment is null)
        {
            return Result<string>.Failure("Appointment not found");
        }

        if (appointment.IsCompleted)
        {
            return Result<string>.Failure("You can not delete completed appointment!");
        }
        appointmentRepository.Delete(appointment);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Appointment delete is successful";
    }
}
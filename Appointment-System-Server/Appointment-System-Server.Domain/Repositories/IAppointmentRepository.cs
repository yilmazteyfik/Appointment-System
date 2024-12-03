using Appointment_System_Server.Domain.Entities;
using GenericRepository;

namespace Appointment_System_Server.Domain.Repositories;

public interface IAppointmentRepository : IRepository<Appointment>
{
}
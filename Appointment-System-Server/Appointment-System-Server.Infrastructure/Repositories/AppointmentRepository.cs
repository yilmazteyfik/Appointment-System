using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using Appointment_System_Server.Infrastructure.Context;
using GenericRepository;

namespace Appointment_System_Server.Infrastructure.Repositories;

internal sealed class AppointmentRepository : Repository<Appointment, ApplicationDbContext>,IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using Appointment_System_Server.Infrastructure.Context;
using GenericRepository;

namespace Appointment_System_Server.Infrastructure.Repositories;

internal sealed class DoctorRepository : Repository<Doctor, ApplicationDbContext>,IDoctorRepository
{
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {
    }
}
using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Repositories;
using Appointment_System_Server.Infrastructure.Context;
using GenericRepository;

namespace Appointment_System_Server.Infrastructure.Repositories;

internal sealed class UserRoleRepository : Repository<AppUserRole, ApplicationDbContext>, IUserRoleRepository
{
    public UserRoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}
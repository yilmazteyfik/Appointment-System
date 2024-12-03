using Appointment_System_Server.Domain.Entities;

namespace Appointment_System_Server.Application.Service;

public interface IJwtProvider
{
    string CreateToken(AppUser user);
}
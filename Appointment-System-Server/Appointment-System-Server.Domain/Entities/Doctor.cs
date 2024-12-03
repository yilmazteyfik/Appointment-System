using Appointment_System_Server.Domain.Enums;

namespace Appointment_System_Server.Domain.Entities;

public sealed class Doctor
{
    public Doctor()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    
    public string FullName => string.Join(" ", FirstName, LastName);

    public DepartmentEnum Department { get; set; } = DepartmentEnum.Acil;

}
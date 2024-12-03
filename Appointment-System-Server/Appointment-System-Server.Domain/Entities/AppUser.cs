using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Identity;

namespace Appointment_System_Server.Domain.Entities;


public sealed class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = String.Empty;
    
    public string LastName { get; set; } = String.Empty;

    public string FullName => string.Join(" ", FirstName, LastName);

}
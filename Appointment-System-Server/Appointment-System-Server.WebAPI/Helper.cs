using Appointment_System_Server.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Appointment_System_Server.WebAPI;

public static class Helper
{
    public static async Task CreateUserAsync(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any(u => u.UserName == "admin"))
            {
                var result = await userManager.CreateAsync(new AppUser()
                {
                    FirstName = "Teyfik",
                    LastName = "YILMAZ",
                    Email = "yilmazteyfik@gmail.com",
                    UserName = "admin",
                }, "1A.");

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error: {error.Description}");
                    }
                }
            }
        }
    }
}
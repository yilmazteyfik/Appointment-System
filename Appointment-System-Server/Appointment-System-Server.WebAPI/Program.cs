using Appointment_System_Server.Application;
using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Infrastructure;
using DefaultCorsPolicyNugetPackage;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDefaultCors();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    
    if (!userManager.Users.Any(u => u.UserName == "admin"))
    {
        var result = userManager.CreateAsync(new AppUser()
        {
            FirstName = "Teyfik",
            LastName = "YILMAZ",
            Email = "yilmazteyfik@gmail.com",
            UserName = "admin",
        }, "1A.").Result;

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Error: {error.Description}");
            }
        }
    }
}

app.Run();


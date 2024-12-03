using Appointment_System_Server.Application;
using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Infrastructure;
using Appointment_System_Server.WebAPI;
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

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await Helper.CreateUserAsync(app);


app.Run();


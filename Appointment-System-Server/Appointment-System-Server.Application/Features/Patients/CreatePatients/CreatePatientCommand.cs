using System.Reflection.Metadata;
using Appointment_System_Server.Application.Features.Doctors.CreateDoctor;
using MediatR;
using TS.Result;

namespace Appointment_System_Server.Application.Features.Patients.CreatePatients;


public sealed record CreatePatientCommand(
    string FirstName,
    string LastName,
    string IdentityNumber,
    string City,
    string Town,
    string FullAddress) : IRequest<Result<string>>;
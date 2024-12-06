using Appointment_System_Server.Application.Features.Doctors.CreateDoctor;
using Appointment_System_Server.Application.Features.Doctors.UpadateDoctor;
using Appointment_System_Server.Application.Features.Patients.CreatePatients;
using Appointment_System_Server.Application.Features.Patients.UpdatePatient;
using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Enums;
using AutoMapper;

namespace Appointment_System_Server.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDoctorCommand, Doctor>().ForMember(member => member.Department, options =>
        {
            options.MapFrom(map => DepartmentEnum.FromValue(map.DepartmentValue));
        });

        CreateMap<UpdateDoctorCommand, Doctor>().ForMember(member => member.Department, options =>
        {
            options.MapFrom(map => DepartmentEnum.FromValue(map.DepartmentValue));
        });

        CreateMap<CreatePatientCommand, Patient>();
        CreateMap<UpdatePatientCommand, Patient>();
    }
}
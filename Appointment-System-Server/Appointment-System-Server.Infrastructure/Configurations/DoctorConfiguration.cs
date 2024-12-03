using Appointment_System_Server.Domain.Entities;
using Appointment_System_Server.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointment_System_Server.Infrastructure.Configurations;

internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
        builder.Property(p => p.LastName).HasColumnType("varchar(50)");
        builder.Property(p => p.Department)
            .HasConversion(v => v.Value, v => DepartmentEnum.FromValue(v))
            .HasColumnName("Department");
    }
}
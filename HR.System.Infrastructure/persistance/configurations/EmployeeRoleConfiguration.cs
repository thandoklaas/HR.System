using HR.System.Domain.entities;
using HRSystem.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.System.Infrastructure.persistance.configurations;

public sealed class EmployeeRoleConfiguration : BaseEntityConfiguration<EmployeeRole>
{
    public override void Configure(EntityTypeBuilder<EmployeeRole> builder)
    {
        base.Configure(builder);

        builder.ToTable("EmployeeRoles");

        builder.HasKey(x => x.EmployeeRoleId);

        builder.Property(x => x.Reason)
            .HasMaxLength(500);

        builder.Property(x => x.IsPrimary)
            .HasDefaultValue(false);

        builder.Property(x => x.EffectiveFrom)
            .IsRequired();

        builder.HasOne(x => x.Employee)
            .WithMany(x => x.EmployeeRoles)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.EmployeeRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AssignedByEmployee)
            .WithMany(x => x.AssignedRoles)
            .HasForeignKey(x => x.AssignedByEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.EmployeeId);

        builder.HasIndex(x => x.RoleId);

        builder.HasIndex(x => x.AssignedByEmployeeId);

        builder.HasIndex(x => new
        {
            x.EmployeeId,
            x.RoleId,
            x.EffectiveFrom
        });

        builder.HasIndex(x => x.EmployeeId)
            .HasFilter("[IsPrimary] = 1 AND [EffectiveTo] IS NULL")
            .IsUnique();
    }
}
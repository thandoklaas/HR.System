using HR.System.Domain.entities;
using HRSystem.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.System.Infrastructure.persistance.configurations;

public sealed class RoleConfiguration : BaseEntityConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder.ToTable("Roles");

        builder.HasKey(x => x.RoleId);

        builder.Property(x => x.RoleName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.RoleCode)
            .HasMaxLength(20);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.IsSystemRole)
            .HasDefaultValue(false);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasMany(x => x.EmployeeRoles)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.RoleName)
            .IsUnique();

        builder.HasIndex(x => x.RoleCode)
            .IsUnique();
    }
}
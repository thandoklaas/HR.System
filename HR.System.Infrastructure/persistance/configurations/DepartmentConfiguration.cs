using HR.System.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystem.Infrastructure.Persistence.Configurations;

public sealed class DepartmentConfiguration : BaseEntityConfiguration<Department>
{
    public override void Configure(EntityTypeBuilder<Department> builder)
    {
        base.Configure(builder);

        builder.ToTable("Departments");

        builder.HasKey(x => x.DepartmentId);

        builder.Property(x => x.DepartmentName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DepartmentCode)
            .HasMaxLength(20);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasMany(x => x.Employees)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.DepartmentName)
            .IsUnique();

        builder.HasIndex(x => x.DepartmentCode)
            .IsUnique();
    }
}
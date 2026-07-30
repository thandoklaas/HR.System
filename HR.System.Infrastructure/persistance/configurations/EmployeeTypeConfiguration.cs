using HR.System.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystem.Infrastructure.Persistence.Configurations;

public sealed class EmployeeTypeConfiguration : BaseEntityConfiguration<EmployeeType>
{
    public override void Configure(EntityTypeBuilder<EmployeeType> builder)
    {
        base.Configure(builder);

        builder.ToTable("EmployeeTypes");

        builder.HasKey(x => x.EmployeeTypeId);

        builder.Property(x => x.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Code)
            .HasMaxLength(20);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasMany(x => x.Employees)
            .WithOne(x => x.EmployeeType)
            .HasForeignKey(x => x.EmployeeTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Description)
            .IsUnique();

        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
}
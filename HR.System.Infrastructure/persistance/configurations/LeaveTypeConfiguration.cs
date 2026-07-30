using HR.System.Domain.entities;
using HRSystem.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.System.Infrastructure.persistance.configurations;

public sealed class LeaveTypeConfiguration : BaseEntityConfiguration<LeaveType>
{
    public override void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        base.Configure(builder);

        builder.ToTable("LeaveTypes");

        builder.HasKey(x => x.LeaveTypeId);

        builder.Property(x => x.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.RequiresDocument)
            .HasDefaultValue(false);

        builder.Property(x => x.DefaultDaysPerYear)
            .HasPrecision(5, 2);

        builder.Property(x => x.MaxDaysPerRequest)
            .HasPrecision(5, 2);

        builder.Property(x => x.IsPaidLeave)
            .HasDefaultValue(true);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasMany(x => x.LeaveRequests)
            .WithOne(x => x.LeaveType)
            .HasForeignKey(x => x.LeaveTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.LeaveBalances)
            .WithOne(x => x.LeaveType)
            .HasForeignKey(x => x.LeaveTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Description)
            .IsUnique();

        builder.HasIndex(x => x.IsActive);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "CK_LeaveType_DefaultDaysPerYear",
                "[DefaultDaysPerYear] >= 0");

            t.HasCheckConstraint(
                "CK_LeaveType_MaxDaysPerRequest",
                "[MaxDaysPerRequest] >= 0");
        });
    }
}
using HR.System.Domain.entities;
using HRSystem.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.System.Infrastructure.persistance.configurations;

public sealed class LeaveBalanceConfiguration : BaseEntityConfiguration<LeaveBalance>
{
    public override void Configure(EntityTypeBuilder<LeaveBalance> builder)
    {
        base.Configure(builder);

        builder.ToTable("LeaveBalances");

        builder.HasKey(x => x.LeaveBalanceId);

        builder.Property(x => x.LeaveYear)
            .IsRequired();

        builder.Property(x => x.AllocatedDays)
            .HasPrecision(5, 2)
            .HasDefaultValue(0);

        builder.Property(x => x.CarriedForwardDays)
            .HasPrecision(5, 2)
            .HasDefaultValue(0);

        builder.Property(x => x.AdjustmentDays)
            .HasPrecision(5, 2)
            .HasDefaultValue(0);

        builder.Property(x => x.TakenDays)
            .HasPrecision(5, 2)
            .HasDefaultValue(0);

        builder.Property(x => x.RemainingDays)
            .HasPrecision(5, 2)
            .HasDefaultValue(0);

        builder.Property(x => x.LastCalculatedDate)
            .IsRequired();

        builder.Property(x => x.IsLocked)
            .HasDefaultValue(false);

        // Employee
        builder.HasOne(x => x.Employee)
            .WithMany(x => x.LeaveBalances)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Leave Type
        builder.HasOne(x => x.LeaveType)
            .WithMany(x => x.LeaveBalances)
            .HasForeignKey(x => x.LeaveTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.EmployeeId);

        builder.HasIndex(x => x.LeaveTypeId);

        builder.HasIndex(x => x.LeaveYear);

        builder.HasIndex(x => new
        {
            x.EmployeeId,
            x.LeaveTypeId,
            x.LeaveYear
        })
        .IsUnique();

        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "CK_LeaveBalance_AllocatedDays",
                "[AllocatedDays] >= 0");

            t.HasCheckConstraint(
                "CK_LeaveBalance_CarriedForwardDays",
                "[CarriedForwardDays] >= 0");

            t.HasCheckConstraint(
                "CK_LeaveBalance_AdjustmentDays",
                "[AdjustmentDays] >= -365");

            t.HasCheckConstraint(
                "CK_LeaveBalance_TakenDays",
                "[TakenDays] >= 0");

            t.HasCheckConstraint(
                "CK_LeaveBalance_RemainingDays",
                "[RemainingDays] >= 0");
        });
    }
}
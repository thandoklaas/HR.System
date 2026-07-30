using HR.System.Domain.entities;
using HRSystem.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.System.Infrastructure.persistance.configurations;

public sealed class LeaveRequestConfiguration : BaseEntityConfiguration<LeaveRequest>
{
    public override void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        base.Configure(builder);


        builder.ToTable("LeaveRequests", table =>
        {
            table.HasCheckConstraint(
                "CK_LeaveRequest_Duration",
                "[Duration] > 0");

            table.HasCheckConstraint(
                "CK_LeaveRequest_Dates",
                "[EndDateTime] >= [StartDateTime]");
        });

        builder.HasKey(x => x.LeaveRequestId);

        builder.Property(x => x.Duration)
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(x => x.StartDateTime)
            .IsRequired();

        builder.Property(x => x.EndDateTime)
            .IsRequired();

        builder.Property(x => x.LeaveSession)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.CurrentWorkflowLevel)
            .HasDefaultValue(1);

        builder.Property(x => x.SickNoteRequired)
            .HasDefaultValue(false);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.Property(x => x.Reason)
            .HasMaxLength(1000);

        builder.Property(x => x.RejectionReason)
            .HasMaxLength(1000);

        // Employee
        builder.HasOne(x => x.Employee)
            .WithMany(x => x.LeaveRequests)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Leave Type
        builder.HasOne(x => x.LeaveType)
            .WithMany(x => x.LeaveRequests)
            .HasForeignKey(x => x.LeaveTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Current Status
        builder.HasOne(x => x.CurrentStatus)
            .WithMany(x => x.LeaveRequests)
            .HasForeignKey(x => x.CurrentStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        // Supporting Document (Optional)
        builder.HasOne(x => x.Document)
            .WithMany(x => x.LeaveRequests)
            .HasForeignKey(x => x.DocumentId)
            .OnDelete(DeleteBehavior.SetNull);

        // Approval History
        builder.HasMany(x => x.LeaveResponses)
            .WithOne(x => x.LeaveRequest)
            .HasForeignKey(x => x.LeaveRequestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.EmployeeId);

        builder.HasIndex(x => x.LeaveTypeId);

        builder.HasIndex(x => x.CurrentStatusId);

        builder.HasIndex(x => x.DocumentId);

        builder.HasIndex(x => x.StartDateTime);

        builder.HasIndex(x => x.EndDateTime);

        builder.HasIndex(x => new
        {
            x.EmployeeId,
            x.StartDateTime
        });

        builder.HasIndex(x => new
        {
            x.EmployeeId,
            x.CurrentStatusId
        });

    }
}
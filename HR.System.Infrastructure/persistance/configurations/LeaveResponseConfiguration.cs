using HR.System.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystem.Infrastructure.Persistence.Configurations;

public sealed class LeaveResponseConfiguration : BaseEntityConfiguration<LeaveResponse>
{
    public override void Configure(EntityTypeBuilder<LeaveResponse> builder)
    {
        base.Configure(builder);

        builder.ToTable("LeaveResponses",
            table => table.HasCheckConstraint(
                             "CK_LeaveResponse_WorkflowLevel",
                             "[WorkflowLevel] > 0")
        );

        builder.HasKey(x => x.LeaveResponseId);

        builder.Property(x => x.Comment)
            .HasMaxLength(1000);

        builder.Property(x => x.RejectionReason)
            .HasMaxLength(1000);

        builder.Property(x => x.WorkflowLevel)
            .IsRequired();

        builder.Property(x => x.IsCurrent)
            .HasDefaultValue(false);

        builder.Property(x => x.ReviewedDate)
            .IsRequired();

        // Leave Request
        builder.HasOne(x => x.LeaveRequest)
            .WithMany(x => x.LeaveResponses)
            .HasForeignKey(x => x.LeaveRequestId)
            .OnDelete(DeleteBehavior.Cascade);

        // Reviewer
        builder.HasOne(x => x.LeaveResponseEmployee)
            .WithMany(x => x.LeaveResponses)
            .HasForeignKey(x => x.LeaveResponseEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Status
        builder.HasOne(x => x.LeaveStatus)
            .WithMany(x => x.LeaveResponses)
            .HasForeignKey(x => x.LeaveStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.LeaveRequestId);

        builder.HasIndex(x => x.LeaveResponseEmployeeId);

        builder.HasIndex(x => x.LeaveStatusId);

        builder.HasIndex(x => x.ReviewedDate);

        builder.HasIndex(x => new
        {
            x.LeaveRequestId,
            x.WorkflowLevel
        });

        builder.HasIndex(x => new
        {
            x.LeaveRequestId,
            x.IsCurrent
        });

        // Ensures only one current workflow step exists per leave request
        builder.HasIndex(x => x.LeaveRequestId)
            .HasFilter("[IsCurrent] = 1")
            .IsUnique();
    }
}
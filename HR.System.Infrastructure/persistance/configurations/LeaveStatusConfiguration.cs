using HR.System.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystem.Infrastructure.Persistence.Configurations;

public sealed class LeaveStatusConfiguration : BaseEntityConfiguration<LeaveStatus>
{
    public override void Configure(EntityTypeBuilder<LeaveStatus> builder)
    {
        base.Configure(builder);

        builder.ToTable("LeaveStatuses");

        builder.HasKey(x => x.LeaveStatusId);

        builder.Property(x => x.Description)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .IsRequired();

        builder.Property(x => x.IsFinalStatus)
            .HasDefaultValue(false);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasMany(x => x.LeaveRequests)
            .WithOne(x => x.CurrentStatus)
            .HasForeignKey(x => x.CurrentStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.LeaveResponses)
            .WithOne(x => x.LeaveStatus)
            .HasForeignKey(x => x.LeaveStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Description)
            .IsUnique();

        builder.HasIndex(x => x.DisplayOrder);

        builder.HasIndex(x => x.IsActive);
    }
}
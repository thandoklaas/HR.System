using HR.System.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystem.Infrastructure.Persistence.Configurations;

public sealed class AuditLogConfiguration : BaseEntityConfiguration<AuditLog>
{
    public override void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        base.Configure(builder);

        builder.ToTable("AuditLogs");

        builder.HasKey(x => x.AuditLogId);

        builder.Property(x => x.TableName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.RecordId)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Action)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.OldValues)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.NewValues)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.ChangedColumns)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.IpAddress)
            .HasMaxLength(50);

        builder.Property(x => x.UserAgent)
            .HasMaxLength(500);

        builder.Property(x => x.CommandName)
            .HasMaxLength(250);

        builder.Property(x => x.EventName)
            .HasMaxLength(250);

        builder.Property(x => x.MachineName)
            .HasMaxLength(100);

        builder.Property(x => x.Environment)
            .HasMaxLength(50);

        builder.Property(x => x.LoggedDate)
            .IsRequired();

        builder.HasOne(x => x.PerformedByEmployee)
            .WithMany(x => x.PerformedAuditLogs)
            .HasForeignKey(x => x.PerformedByEmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(x => x.PerformedByEmployeeId);

        builder.HasIndex(x => x.TableName);

        builder.HasIndex(x => x.Action);

        builder.HasIndex(x => x.LoggedDate);

        builder.HasIndex(x => x.CorrelationId);

        builder.HasIndex(x => x.RequestId);
    }
}
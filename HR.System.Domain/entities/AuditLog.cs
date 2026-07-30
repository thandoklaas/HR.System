
using HR.System.Domain.Common;

namespace HR.System.Domain.entities;

public class AuditLog : BaseEntity
{
    public long AuditLogId { get; set; }

    public string TableName { get; set; } = string.Empty;

    public string RecordId { get; set; } = string.Empty;

    public string Action { get; set; } = string.Empty;

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? ChangedColumns { get; set; }

    public int? PerformedByEmployeeId { get; set; }

    public Employee? PerformedByEmployee { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public Guid? CorrelationId { get; set; }

    public Guid? RequestId { get; set; }

    public string? CommandName { get; set; }

    public string? EventName { get; set; }

    public string? MachineName { get; set; }

    public string? Environment { get; set; }

    public DateTimeOffset LoggedDate { get; set; }

}


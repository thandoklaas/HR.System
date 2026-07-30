using HR.System.Domain.Common;

namespace HR.System.Domain.entities;
public class LeaveResponse : BaseEntity
{
    public int LeaveResponseId { get; set; }

    public int LeaveRequestId { get; set; }

    public LeaveRequest LeaveRequest { get; set; } = null!;

    public int LeaveResponseEmployeeId { get; set; }

    public Employee LeaveResponseEmployee { get; set; } = null!;

    public int LeaveStatusId { get; set; }

    public LeaveStatus LeaveStatus { get; set; } = null!;

    public string? Comment { get; set; }

    public string? RejectionReason { get; set; }

    public int WorkflowLevel { get; set; }

    public bool IsCurrent { get; set; }

    public DateTimeOffset ReviewedDate { get; set; }

}

using HR.System.Domain.Common;
using HR.System.Domain.enums;
namespace HR.System.Domain.entities;

public class LeaveRequest : BaseEntity
{
    public int LeaveRequestId { get; set; }

    public int EmployeeId { get; set; }

    public Employee Employee { get; set; } = null!;

    public int LeaveTypeId { get; set; }

    public LeaveType LeaveType { get; set; } = null!;

    public int CurrentStatusId { get; set; }

    public LeaveStatus CurrentStatus { get; set; } = null!;

    public int? DocumentId { get; set; }

    public Document? Document { get; set; }

    public DateTimeOffset StartDateTime { get; set; }

    public DateTimeOffset EndDateTime { get; set; }

    public decimal Duration { get; set; }

    public LeaveSession LeaveSession { get; set; }

    public bool SickNoteRequired { get; set; }

    public bool IsActive { get; set; } = true;

    public int CurrentWorkflowLevel { get; set; }

    public string? Reason { get; set; }

    public string? RejectionReason { get; set; }

    public ICollection<LeaveResponse> LeaveResponses { get; set; }
        = new List<LeaveResponse>();
}
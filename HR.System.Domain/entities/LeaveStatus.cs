using HR.System.Domain.Common;

namespace HR.System.Domain.entities;
public class LeaveStatus : BaseEntity
{
    public int LeaveStatusId { get; set; }

    public string Description { get; set; } = string.Empty;

    public bool IsFinalStatus { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<LeaveRequest> LeaveRequests { get; set; }
        = new List<LeaveRequest>();

    public ICollection<LeaveResponse> LeaveResponses { get; set; }
        = new List<LeaveResponse>();
}

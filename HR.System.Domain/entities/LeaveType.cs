using HR.System.Domain.Common;

namespace HR.System.Domain.entities;
public class LeaveType : BaseEntity
{
    public int LeaveTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public bool RequiresDocument { get; set; }

    public decimal DefaultDaysPerYear { get; set; }

    public decimal MaxDaysPerRequest { get; set; }

    public bool IsPaidLeave { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<LeaveRequest> LeaveRequests { get; set; }
        = new List<LeaveRequest>();

    public ICollection<LeaveBalance> LeaveBalances { get; set; }
        = new List<LeaveBalance>();
}
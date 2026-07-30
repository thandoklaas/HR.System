using HR.System.Domain.Common;
namespace HR.System.Domain.entities;

public class LeaveBalance : BaseEntity
{
    public int LeaveBalanceId { get; set; }

    public int EmployeeId { get; set; }

    public Employee Employee { get; set; } = null!;

    public int LeaveTypeId { get; set; }

    public LeaveType LeaveType { get; set; } = null!;

    public int LeaveYear { get; set; }

    public decimal AllocatedDays { get; set; }

    public decimal CarriedForwardDays { get; set; }

    public decimal AdjustmentDays { get; set; }

    public decimal TakenDays { get; set; }

    public decimal RemainingDays { get; set; }

    public DateTimeOffset LastCalculatedDate { get; set; }

    public bool IsLocked { get; set; }
}
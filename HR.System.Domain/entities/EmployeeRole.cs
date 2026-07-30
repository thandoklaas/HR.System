using HR.System.Domain.Common;

namespace HR.System.Domain.entities;

public class EmployeeRole : BaseEntity
{
    public int EmployeeRoleId { get; set; }

    // Employee receiving the role
    public int EmployeeId { get; set; }

    public Employee Employee { get; set; } = null!;

    // Assigned role
    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;

    // Employee who assigned the role
    public int? AssignedByEmployeeId { get; set; }

    public Employee? AssignedByEmployee { get; set; }

    // Effective period
    public DateOnly EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    // Indicates the employee's primary role
    public bool IsPrimary { get; set; }

    // Optional reason for assignment/change
    public string? Reason { get; set; }
}
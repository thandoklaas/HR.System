using HR.System.Domain.Common;

namespace HR.System.Domain.entities;

public class Role : BaseEntity
{
    public int RoleId { get; set; }

    public required string RoleName { get; set; }

    public string? RoleCode { get; set; }

    public string? Description { get; set; }

    public bool IsSystemRole { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation Property
    public ICollection<EmployeeRole> EmployeeRoles { get; set; }
        = new List<EmployeeRole>();
}
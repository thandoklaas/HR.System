using HR.System.Domain.Common;

namespace HR.System.Domain.entities;
public class Department : BaseEntity
{
    public int DepartmentId { get; set; }

    public required string DepartmentName { get; set; }

    public string? DepartmentCode { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation Property
    public ICollection<Employee> Employees { get; set; }
        = new List<Employee>();
}


using HR.System.Domain.Common;

namespace HR.System.Domain.entities;

public class EmployeeType : BaseEntity
{
    public int EmployeeTypeId { get; set; }

    public required string Description { get; set; }

    public string? Code { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation Property
    public ICollection<Employee> Employees { get; set; }
        = new List<Employee>();
}


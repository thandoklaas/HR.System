using HR.System.Domain.Common;

namespace HR.System.Domain.entities;

public class JobTitle : BaseEntity
{
    public int JobTitleId { get; set; }

    public string JobTitleName { get; set; } = string.Empty;

    public string? JobCode { get; set; }

    public string? Description { get; set; }

    public bool IsManagementRole { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Employee> Employees { get; set; }
        = new List<Employee>();
}

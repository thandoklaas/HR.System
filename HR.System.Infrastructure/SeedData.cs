
using HR.System.Domain.entities;

namespace HR.System.Infrastructure;

public static class SeedData
{
    public static IReadOnlyList<Department> Departments => new List<Department>
    {
            new()
            {
                Description = "Human Resources department",
                DepartmentName = "Human Resources",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow
            },
            new()
            {
               Description = "Information Technology department",
                DepartmentName = "Information Technology",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow
            },
            new()
            {
                Description = "Finance department",
                DepartmentName = "Finance",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow
            },
            new()
            {
                Description = "Operations department",
                DepartmentName = "Operations",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow
            },
            new()
            {
                Description = "Executive department",
                DepartmentName = "Executive",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow
            }
    };

    public static IReadOnlyList<JobTitle> JobTitles => new List<JobTitle>
    {
        new()
        {
            Description = "Software Developer",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        },
        new()
        {
            Description = "Senior Software Developer",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        },
        new()
        {
            Description = "Marketing Analyst",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        },
        new()
        {
            Description = "Development Manager",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        },
        new()
        {
            Description = "HR Administrator",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        },
        new()
        {
            Description = "HR Manager",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        },
        new()
        {
            Description = "Chief Executive Officer",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        }

    };

    public static IReadOnlyList<EmployeeType> EmployeeTypes => new List<EmployeeType>
    {
        new() { Description = "Permanent" },
        new() { Description = "Contract" },
        new() { Description = "Temporary" },
        new() { Description = "Intern" },
        new() { Description = "Consultant" }
    };

    public static IReadOnlyList<LeaveType> LeaveTypes => new List<LeaveType>
    {
        new()
        {
            Description = "Annual Leave",
            RequiresDocument = false,
            MaxDaysPerRequest = 21,
            IsActive = true,
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        },
        new()
        {
            Description = "Sick Leave",
            RequiresDocument = true,
            MaxDaysPerRequest = 30,
            IsActive = true,
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        },
        new()
        {
            Description = "Study Leave",
            RequiresDocument = false,
            MaxDaysPerRequest = 10,
            IsActive = true,
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        }
    };

    public static IReadOnlyList<LeaveStatus> LeaveStatuses => new List<LeaveStatus>
    {
        new()
        {
            Description = "Pending",
            DisplayOrder = 1,
            IsFinalStatus = false,
            IsActive = true,
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        },
        new()
        {
            Description = "Approved",
            DisplayOrder = 2,
            IsFinalStatus = true,
            IsActive = true,
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        },
        new()
        {
            Description = "Rejected",
            DisplayOrder = 3,
            IsFinalStatus = true,
            IsActive = true,
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow
        }
    };
}
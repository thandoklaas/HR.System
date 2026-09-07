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
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsDeleted =false
            },
            new()
            {
               Description = "Information Technology department",
                DepartmentName = "Information Technology",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsDeleted =false
            },
            new()
            {
                Description = "Finance department",
                DepartmentName = "Finance",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsDeleted =false
            },
            new()
            {
                Description = "Operations department",
                DepartmentName = "Operations",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsDeleted =false
            },
            new()
            {
                Description = "Executive department",
                DepartmentName = "Executive",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsDeleted =false
            }
    };

    public static IReadOnlyList<JobTitle> JobTitles => new List<JobTitle>
    {
        new()
        {
            JobTitleName = "Dev2",
            Description = "Software Developer",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsDeleted =false,
            JobCode = "SD001",
        },
        new()
        {
            JobTitleName = "Dev3",
            Description = "Senior Software Developer",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsDeleted =false,
            JobCode = "SD003",
        },
        new()
        {
                        JobTitleName = "ANLST2",
            Description = "Marketing Analyst",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsDeleted =false,
            JobCode = "SD004",
        },
        new()
        {
            JobTitleName = "Dev6",
            Description = "Development Manager",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsDeleted =false,
            JobCode = "SD005",
        },
        new()
        {
            JobTitleName = "HR2",
            Description = "HR Administrator",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsDeleted =false,
            JobCode = "SD006",
        },
        new()
        {
            JobTitleName = "HR6",
            Description = "HR Manager",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow,
                        IsActive = true,
            IsDeleted =false,
            JobCode = "SD007",
        },
        new()
        {
            JobTitleName = "CHIEF1",
            Description = "Chief Executive Officer",
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsDeleted =false,
            JobCode = "SD008",
        }

    };

    public static IReadOnlyList<EmployeeType> EmployeeTypes => new List<EmployeeType>
    {
        new() { Description = "Permanent",  Code ="PRMT", IsActive = true, CreatedBy ="Stystem", CreatedDate =DateTimeOffset.Now, IsDeleted =false},
        new() { Description = "Contract",  Code ="CONT", IsActive = true, CreatedBy ="Stystem", CreatedDate =DateTimeOffset.Now, IsDeleted =false},
        new() { Description = "Temporary",  Code ="TEMP", IsActive = true, CreatedBy ="Stystem", CreatedDate =DateTimeOffset.Now, IsDeleted =false},
        new() { Description = "Intern" ,  Code ="INT", IsActive = true, CreatedBy ="Stystem", CreatedDate =DateTimeOffset.Now, IsDeleted =false},
        new() { Description = "Consultant" , Code ="CONS", IsActive = true, CreatedBy ="Stystem", CreatedDate =DateTimeOffset.Now, IsDeleted =false }
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
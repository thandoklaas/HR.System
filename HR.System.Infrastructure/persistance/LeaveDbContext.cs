using HR.System.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace HR.System.Infrastructure.persistance;

public class LeaveDbContext : DbContext
{
    public LeaveDbContext(DbContextOptions<LeaveDbContext> options)
        : base(options)
    {
    }

    public LeaveDbContext()
    {

    }
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<ContactDetail> ContactDetails => Set<ContactDetail>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<EmployeeRole> EmployeeRoles => Set<EmployeeRole>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<EmployeeType> EmployeeTypes => Set<EmployeeType>();
    public DbSet<JobTitle> JobTitles => Set<JobTitle>();
    public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
    public DbSet<LeaveResponse> LeaveResponses => Set<LeaveResponse>();
    public DbSet<LeaveBalance> LeaveBalances => Set<LeaveBalance>();
    public DbSet<LeaveType> LeaveTypes => Set<LeaveType>();
    public DbSet<LeaveStatus> LeaveStatuses => Set<LeaveStatus>();
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveDbContext).Assembly);
    }
}
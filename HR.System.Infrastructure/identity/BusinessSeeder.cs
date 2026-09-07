
using HR.System.Infrastructure.persistance;
using Microsoft.EntityFrameworkCore;

namespace HR.System.Infrastructure.identity;

public class BusinessDataSeeder
{
    private readonly LeaveDbContext _context;
    public BusinessDataSeeder(LeaveDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.MigrateAsync();

        await SeedDepartments();

        await SeedJobTitles();

        await SeedLeaveTypes();

        await SeedEmployeeTypes();

        await SeedWorkflowLevels();

        await _context.SaveChangesAsync();
    }

   
    private async Task SeedDepartments()
    {
        if (!await _context.Departments.AnyAsync())
            await _context.Departments.AddRangeAsync(SeedData.Departments);
    }

    private async Task SeedJobTitles()
    {
        if (!await _context.JobTitles.AnyAsync())
            await _context.JobTitles.AddRangeAsync(SeedData.JobTitles);
    }

   
    private async Task SeedLeaveTypes()
    {
        if (!await _context.LeaveTypes.AnyAsync())
            await _context.LeaveTypes.AddRangeAsync(SeedData.LeaveTypes);
    }

    private async Task SeedEmployeeTypes()
    {
        if (!await _context.EmployeeTypes.AnyAsync())
            await _context.EmployeeTypes.AddRangeAsync(SeedData.EmployeeTypes);
    }

    private async Task SeedWorkflowLevels()
    {
        if (!await _context.LeaveStatuses.AnyAsync())
            await _context.LeaveStatuses.AddRangeAsync(SeedData.LeaveStatuses);
    }

    private async Task SeedIdentityRole()
    {
        if (!await _context.LeaveStatuses.AnyAsync())
            await _context.LeaveStatuses.AddRangeAsync(SeedData.LeaveStatuses);
    }
}

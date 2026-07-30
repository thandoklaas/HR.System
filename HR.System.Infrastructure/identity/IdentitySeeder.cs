using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HR.System.Infrastructure.identity;

public sealed class IdentitySeeder
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentitySeeder(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAsync()
    {
        await SeedRoles();

        await SeedAdministrator();
    }

    #region Roles

    private async Task SeedRoles()
    {
        await CreateRoleIfNotExists(Roles.Employee);
        await CreateRoleIfNotExists(Roles.Manager);
        await CreateRoleIfNotExists(Roles.HR);
        await CreateRoleIfNotExists(Roles.Administrator);
    }

    private async Task CreateRoleIfNotExists(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
            return;

        await _roleManager.CreateAsync(new IdentityRole(roleName));
    }

    #endregion

    #region Administrator

    private async Task SeedAdministrator()
    {
        const string email = "admin@hrsystem.co.za";
        const string password = "Admin@12345";

        var user = await CreateUserIfNotExists(
            email,
            password,
            "System",
            "Administrator");

        await AssignRole(user, Roles.Administrator);

        await AssignClaims(user);
    }

    private async Task<ApplicationUser> CreateUserIfNotExists(
        string email,
        string password,
        string firstName,
        string lastName)
    {
        var existing = await _userManager.Users
            .FirstOrDefaultAsync(x => x.Email == email);

        if (existing != null)
            return existing;

        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            throw new Exception(
                string.Join(Environment.NewLine,
                    result.Errors.Select(e => e.Description)));
        }

        return user;
    }

    private async Task AssignRole(
        ApplicationUser user,
        string role)
    {
        if (await _userManager.IsInRoleAsync(user, role))
            return;

        await _userManager.AddToRoleAsync(user, role);
    }

    private async Task AssignClaims(ApplicationUser user)
    {
        var existingClaims = await _userManager.GetClaimsAsync(user);

        var claims = new[]
        {
            new Claim(Permissions.Employees.View,"true"),
            new Claim(Permissions.Employees.Create,"true"),
            new Claim(Permissions.Employees.Update,"true"),
            new Claim(Permissions.Employees.Delete,"true"),

            new Claim(Permissions.Leave.View,"true"),
            new Claim(Permissions.Leave.Create,"true"),
            new Claim(Permissions.Leave.Approve,"true"),
            new Claim(Permissions.Leave.Reject,"true"),
            new Claim(Permissions.Leave.Cancel,"true"),

            new Claim(Permissions.Documents.Upload,"true"),
            new Claim(Permissions.Documents.Download,"true"),
            new Claim(Permissions.Documents.Delete,"true"),

            new Claim(Permissions.Administration.ManageUsers,"true"),
            new Claim(Permissions.Administration.ManageRoles,"true"),
            new Claim(Permissions.Administration.Audit,"true")
        };

        foreach (var claim in claims)
        {
            if (existingClaims.Any(c =>
                c.Type == claim.Type &&
                c.Value == claim.Value))
            {
                continue;
            }

            await _userManager.AddClaimAsync(user, claim);
        }
    }

    #endregion
}
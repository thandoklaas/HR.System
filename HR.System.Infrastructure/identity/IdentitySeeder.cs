using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR.System.Infrastructure.identity;

public sealed class IdentitySeeder
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public IdentitySeeder(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAsync(
        CancellationToken cancellationToken = default)
    {
        await SeedRolesAsync(cancellationToken);
        await SeedAdministratorAsync(cancellationToken);
    }

    private async Task SeedRolesAsync(
        CancellationToken cancellationToken)
    {
        var roles = new[]
        {
            Roles.Employee,
            Roles.Manager,
            Roles.HR,
            Roles.Administrator
        };

        foreach (var roleName in roles)
        {
            await CreateRoleIfNotExistsAsync(
                roleName,
                cancellationToken);
        }
    }

    private async Task CreateRoleIfNotExistsAsync(
        string roleName,
        CancellationToken cancellationToken)
    {
        var exists = await _roleManager.RoleExistsAsync(roleName);

        if (exists)
        {
            return;
        }

        var role = new ApplicationRole
        {
            Name = roleName,
            NormalizedName = roleName.ToUpperInvariant()
        };

        var result = await _roleManager.CreateAsync(role);

        EnsureSucceeded(
            result,
            $"Failed to create role '{roleName}'.");
    }

    private async Task SeedAdministratorAsync(
        CancellationToken cancellationToken)
    {
        const string email = "admin@hrsystem.co.za";
        const string password = "Admin@12345";

        var user = await FindUserByEmailAsync(email);

        if (user is null)
        {
            user = await CreateAdministratorAsync(
                email,
                password,
                cancellationToken);
        }

        await AssignRoleAsync(
            user,
            Roles.Administrator);

        await AssignAdministratorClaimsAsync(
            user);
    }

    private async Task<ApplicationUser?> FindUserByEmailAsync(
        string email)
    {
        return await _userManager.Users
            .FirstOrDefaultAsync(
                x => x.Email == email);
    }

    private async Task<ApplicationUser> CreateAdministratorAsync(
        string email,
        string password,
        CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FirstName = "System",
            LastName = "Administrator",
            EmailConfirmed = true,
            IsActive = true,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "IdentitySeeder"
        };

        var result = await _userManager.CreateAsync(
            user,
            password);

        EnsureSucceeded(
            result,
            $"Failed to create administrator '{email}'.");

        return user;
    }

    private async Task AssignRoleAsync(
        ApplicationUser user,
        string role)
    {
        if (await _userManager.IsInRoleAsync(user, role))
        {
            return;
        }

        var result = await _userManager.AddToRoleAsync(
            user,
            role);

        EnsureSucceeded(
            result,
            $"Failed to assign role '{role}' to '{user.Email}'.");
    }

    private async Task AssignAdministratorClaimsAsync(
        ApplicationUser user)
    {
        var existingClaims =
            await _userManager.GetClaimsAsync(user);

        var claims = GetAdministratorClaims();

        foreach (var claim in claims)
        {
            var exists = existingClaims.Any(existing =>
                existing.Type == claim.Type &&
                existing.Value == claim.Value);

            if (exists)
            {
                continue;
            }

            var result = await _userManager.AddClaimAsync(
                user,
                claim);

            EnsureSucceeded(
                result,
                $"Failed to add claim '{claim.Type}' to '{user.Email}'.");
        }
    }

    private static IEnumerable<Claim> GetAdministratorClaims()
    {
        return
        [
            new Claim(Permissions.Employees.View, "true"),
            new Claim(Permissions.Employees.Create, "true"),
            new Claim(Permissions.Employees.Update, "true"),
            new Claim(Permissions.Employees.Delete, "true"),

            new Claim(Permissions.Leave.View, "true"),
            new Claim(Permissions.Leave.Create, "true"),
            new Claim(Permissions.Leave.Approve, "true"),
            new Claim(Permissions.Leave.Reject, "true"),
            new Claim(Permissions.Leave.Cancel, "true"),

            new Claim(Permissions.Documents.Upload, "true"),
            new Claim(Permissions.Documents.Download, "true"),
            new Claim(Permissions.Documents.Delete, "true"),

            new Claim(
                Permissions.Administration.ManageUsers,
                "true"),

            new Claim(
                Permissions.Administration.ManageRoles,
                "true"),

            new Claim(
                Permissions.Administration.Audit,
                "true")
        ];
    }

    private static void EnsureSucceeded(
        IdentityResult result,
        string message)
    {
        if (result.Succeeded)
        {
            return;
        }

        var errors = string.Join(
            "; ",
            result.Errors.Select(e =>
                $"{e.Code}: {e.Description}"));

        throw new InvalidOperationException(
            $"{message} {errors}");
    }
}
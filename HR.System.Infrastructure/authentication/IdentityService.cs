using HR.System.Application.interfaces;
using HR.System.Infrastructure.identity;
using Microsoft.AspNetCore.Identity;

namespace HR.System.Infrastructure.authentication;

public sealed class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityLoginResult?> LoginAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default)
    {
        var user =
            await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            return null;
        }

        if (!user.IsActive)
        {
            return new IdentityLoginResult
            {
                UserId = user.Id,
                Email = user.Email ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = false,
                Roles = []
            };
        }

        var result =
            await _signInManager.CheckPasswordSignInAsync(
                user,
                password,
                lockoutOnFailure: true);

        if (result.IsLockedOut)
        {
            return null;
        }

        if (!result.Succeeded)
        {
            return null;
        }

        var roles =
            await _userManager.GetRolesAsync(user);

        user.LastLoginDate = DateTime.UtcNow;

        await _userManager.UpdateAsync(user);

        return new IdentityLoginResult
        {
            UserId = user.Id,
            Email = user.Email ?? string.Empty,
            FirstName = user.FirstName,
            LastName = user.LastName,
            IsActive = user.IsActive,
            Roles = roles
        };
    }
}

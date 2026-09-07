using Microsoft.AspNetCore.Identity;
namespace HR.System.Infrastructure.identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public int? EmployeeId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public string CreatedBy { get; set; } = "System";

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }
}
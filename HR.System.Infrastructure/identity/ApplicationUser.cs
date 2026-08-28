using Microsoft.AspNet.Identity.EntityFramework;

namespace HR.System.Infrastructure.identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Links the Identity user to the HR Employee record.
    /// Nullable because an Identity user may exist before an employee profile is created.
    /// </summary>
    public int? EmployeeId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public string CreatedBy { get; set; } = "System";

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public ICollection<ApplicationRole> Roles { get; set; } = null!;
}
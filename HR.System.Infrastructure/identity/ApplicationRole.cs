using Microsoft.AspNetCore.Identity;

namespace HR.System.Infrastructure.identity;

public class ApplicationRole : IdentityRole<int>
{
    public string Description { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public string CreatedBy { get; set; } = "System";
}
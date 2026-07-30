using HR.System.Domain.Common;

namespace HR.System.Domain.entities;

public class ContactDetail : BaseEntity
{
    public int ContactDetailId { get; set; }

    public required string Mobile { get; set; }

    public string? AlternateMobile { get; set; }

    public required string Email { get; set; }

    public string? WorkEmail { get; set; }

    // One-to-One Navigation
    public Employee? Employee { get; set; }

}

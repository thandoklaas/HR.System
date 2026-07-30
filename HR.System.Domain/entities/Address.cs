
using HR.System.Domain.Common;

namespace HR.System.Domain.entities;

public class Address : BaseEntity
{
    public int AddressId { get; set; }

    public string? UnitNumber { get; set; }

    public required string Street { get; set; }

    public required string Suburb { get; set; }

    public required string Town { get; set; }

    public required string Province { get; set; }

    public required string PostalCode { get; set; }

    // Navigation Property (One-to-One)
    public Employee? Employee { get; set; }
}
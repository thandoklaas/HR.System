
namespace HR.System.Domain.Common
{
    public interface IAuditableEntity
    {
        DateTimeOffset CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTimeOffset? ModifiedDate { get; set; }
        string? ModifiedBy { get; set; }
    }
}

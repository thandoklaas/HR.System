
namespace HR.System.Domain.Common
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }

        DateTimeOffset? DeletedDate { get; set; }

        string? DeletedBy { get; set; }
    }
}

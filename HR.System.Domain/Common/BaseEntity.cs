using MediatR;

namespace HR.System.Domain.Common;

public abstract class BaseEntity : IAuditableEntity, ISoftDelete
{
    /// <summary>
    /// Date the entity was created.
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }

    /// <summary>
    /// User that created the entity.
    /// </summary>
    public string CreatedBy { get; set; } = string.Empty;

    /// <summary>
    /// Date the entity was last modified.
    /// </summary>
    public DateTimeOffset? ModifiedDate { get; set; }

    /// <summary>
    /// User that last modified the entity.
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Soft delete flag.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Date the entity was deleted.
    /// </summary>
    public DateTimeOffset? DeletedDate { get; set; }

    /// <summary>
    /// User that deleted the entity.
    /// </summary>
    public string? DeletedBy { get; set; }

    /// <summary>
    /// SQL Server optimistic concurrency token.
    /// </summary>
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();

    //--------------------------------------------------------
    // Domain Events
    //--------------------------------------------------------

    private readonly List<INotification> _domainEvents = new();

    public IReadOnlyCollection<INotification> DomainEvents =>
        _domainEvents.AsReadOnly();

    public void AddDomainEvent(INotification domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(INotification domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

namespace HR.System.Infrastructure.repository;

/// <summary>
/// Interface for providing database
/// transaction support
/// </summary>
public interface IDatabaseTransaction : IDisposable
{
    /// <summary>
    /// Commit the changes that were
    /// made as part of the transaction
    /// </summary>
    void Commit();

    /// <summary>
    /// Rolls back all changes made
    /// as part of the transaction
    /// </summary>
    void Rollback();
}


using HR.System.Application.interfaces;

namespace HR.System.Test.infrastructure;
public class InMemoryDatabaseTransaction : IDatabaseTransaction
{
    public InMemoryDatabaseTransaction()
    {
    }

    public void Commit()
    {
    }

    public void Dispose()
    {
    }

    public void Rollback()
    {
    }
}
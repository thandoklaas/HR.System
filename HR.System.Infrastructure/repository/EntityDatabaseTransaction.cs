using HR.System.Infrastructure.persistance;
using Microsoft.EntityFrameworkCore.Storage;

namespace HR.System.Infrastructure.repository;

public class EntityDatabaseTransaction : IDatabaseTransaction
{
    private readonly IDbContextTransaction _transaction;

    public EntityDatabaseTransaction(LeaveDbContext context)
    {
        _transaction = context.Database.BeginTransaction();
    }

    public void Dispose()
    {
        _transaction.Dispose();
    }

    public void Commit()
    {
        _transaction.Commit();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }
}


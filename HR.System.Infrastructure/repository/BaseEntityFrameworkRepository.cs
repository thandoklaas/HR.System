using HR.System.Infrastructure.persistance;
using System.Linq.Expressions;

namespace HR.System.Infrastructure.repository;

public abstract class BaseEntityFrameworkRepository<T>
    where T : class
{
#nullable disable
    protected LeaveDbContext LeaveContext { get; private set; }
    protected BaseEntityFrameworkRepository(LeaveDbContext context)
    {
        LeaveContext = context;
    }
    ///// <summary>
    /// parameter expression is used to filter the data from the database.
    /// <summary>
    /// Returns an IQueryable expression that
    /// can be built upon by the consumer.
    /// </summary>
    /// <returns>IQueryable expression</returns>
    protected async Task<IQueryable<T>> GetQueryableExpression(Expression<Func<T, bool>> expression = null)
    {
        return LeaveContext.Set<T>().Where(expression);
    }

}


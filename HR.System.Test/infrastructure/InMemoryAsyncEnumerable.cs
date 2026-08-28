using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace HR.System.Test.infrastructure;

public class InMemoryAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
{
    public InMemoryAsyncEnumerable(IEnumerable<T> enumerable) : base(enumerable)
    {
    }

    public InMemoryAsyncEnumerable(Expression expression) : base(expression)
    {
    }

    public IDbAsyncEnumerator<T> GetAsyncEnumerator() => new InMemoryAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());

    IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator() => GetAsyncEnumerator();

    IQueryProvider IQueryable.Provider => new InMemoryQueryProvider<T>(this);
}

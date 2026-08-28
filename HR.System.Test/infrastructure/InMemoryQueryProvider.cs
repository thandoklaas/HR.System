using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace HR.System.Test.infrastructure;

public class InMemoryQueryProvider<T> : IDbAsyncQueryProvider
{
    private readonly IQueryProvider _inner;
    
    public InMemoryQueryProvider(IQueryProvider inner)
    {
        _inner = inner;
    }
    
    public IQueryable CreateQuery(Expression expression) => new InMemoryAsyncEnumerable<T>(expression);
    
    public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => new InMemoryAsyncEnumerable<TElement>(expression);

    public object Execute(Expression expression) => _inner.Execute(expression);

    public TResult Execute<TResult>(Expression expression) => _inner.Execute<TResult>(expression);

    public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken) 
        => Task.FromResult(_inner.Execute(expression));

    public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        => Task.FromResult(_inner.Execute<TResult>(expression));
}
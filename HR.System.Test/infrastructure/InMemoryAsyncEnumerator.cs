using System.Data.Entity.Infrastructure;

namespace HR.System.Test.infrastructure;

public class InMemoryAsyncEnumerator<T> : IDbAsyncEnumerator<T>
{
    private readonly IEnumerator<T> _inner;

    public InMemoryAsyncEnumerator(IEnumerator<T> inner)
    {
        _inner = inner;
    }

    public void Dispose() => _inner.Dispose();

    public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        => Task.FromResult(_inner.MoveNext());

    public T Current => _inner.Current;

    object IDbAsyncEnumerator.Current => Current;
}

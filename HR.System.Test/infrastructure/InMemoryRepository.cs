using HR.System.Application.enums;
using HR.System.Application.interfaces;
using System.Linq.Expressions;

namespace HR.System.Test.infrastructure;

public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly List<T> _data;

    public InMemoryRepository()
    {
        _data = new List<T>();
    }

    public InMemoryRepository(List<T> data)
    {
        _data = data;
    }

    public Task<IQueryable<T>> Queryable()
        => Task.FromResult<IQueryable<T>>(new InMemoryAsyncEnumerable<T>(_data));

    public async Task<List<T>> GetCollectionAsync()
    {
        return await Task.FromResult(_data);
    }

    public async Task<List<T>> GetCollectionByExpressionAsync(Expression<Func<T, bool>> expression, List<string> includes = null)
    {
        return await Task.FromResult(_data.Where(expression.Compile()).ToList());
    }

    public async Task<List<T>> GetCollectionByExpressionAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderby, int? page, int? size)
    {
        var collection = await GetCollectionByExpressionAsync(expression);

        if (page == null || size == null)
            return collection;

        return collection.OrderBy(orderby.Compile())
            .Skip((page.Value - 1) * size.Value)
            .Take(size.Value)
            .ToList();
    }

    public async Task<List<T>> GetCollectionByExpressionAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderby, int? page, int? size, SortDirection orderByDirection = SortDirection.Ascending, List<string> includes = null)
    {
        var collection = await GetCollectionByExpressionAsync(expression);

        if (page == null || size == null)
            return collection;

        return collection.OrderBy(orderby.Compile())
            .Skip((page.Value - 1) * size.Value)
            .Take(size.Value)
            .ToList();
    }

    public async Task<List<T>> GetCollectionByExpressionDescendingAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderby, int? page, int? size)
    {
        var collection = await GetCollectionByExpressionAsync(expression);

        if (page == null || size == null)
            return collection;

        return collection.OrderByDescending(orderby.Compile())
            .Skip((page.Value - 1) * size.Value)
            .Take(size.Value)
            .ToList();
    }

    public async Task<bool> AddAsync(T model)
    {
        _data.Add(model);
        return await Task.FromResult(true);
    }

    public async Task<bool> AddRangeAsync(List<T> models)
    {
        _data.AddRange(models);
        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateAsync(T model)
    {
        // 1. Update the model properties directly
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(T model)
    {
        _data.Remove(model);
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteRangeAsync(List<T> models)
    {
        foreach (var model in models)
        {
            _data.Remove(model);
        }
        return await Task.FromResult(true);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await Task.FromResult(_data.Any(expression.Compile()));
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
    {
        return await Task.FromResult(_data.Where(expression.Compile()).Count());

    }

    public async Task<T> FindAsync(int id)
    {
        T model = null;
        // This should be the primary key of the entity
        var key = typeof(T).GetProperties().FirstOrDefault();

        if (key != null)
        {
            foreach (var item in _data)
            {
                var propValue = key.GetValue(item, null);

                if (!propValue.Equals(id)) continue;

                model = item;
                break;
            }
        }

        return await Task.FromResult(model);
    }

    public async Task<T> GetFirstOrDefaultByExpressionAsync(Expression<Func<T, bool>> expression)
    {
        return await Task.FromResult(_data.FirstOrDefault(expression.Compile()));
    }

    public Task<bool> AllAsync(Expression<Func<T, bool>> expression)
    {
        return Task.FromResult(_data.All(expression.Compile()));
    }
}

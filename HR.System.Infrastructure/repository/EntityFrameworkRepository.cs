using HR.System.Application.enums;
using HR.System.Infrastructure.persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR.System.Infrastructure.repository;
#nullable disable
public class EntityFrameworkRepository<T> : BaseEntityFrameworkRepository<T>, IRepository<T>
    where T : class
{

    public EntityFrameworkRepository(LeaveDbContext db)
        : base(db)
    {
    }

    public async Task<IQueryable<T>> Queryable()
        => await GetQueryableExpression();

    public async Task<List<T>> GetCollectionAsync()
    {

        return await LeaveContext.Set<T>()
            .ToListAsync();
    }

    public async Task<List<T>> GetCollectionByExpressionAsync(Expression<Func<T, bool>> expression, List<string> includes = null)
    {

        var query = LeaveContext.Set<T>()
            .Where(expression);

        query = ApplyIncludes(includes, query);

        return await query.ToListAsync();
    }

    private static IQueryable<T> ApplyIncludes(List<string> includes, IQueryable<T> query)
    {
        if (includes == null)
            return query;

        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }

    public async Task<List<T>> GetCollectionByExpressionAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderBy, int? page, int? size, SortDirection orderByDirection = SortDirection.Ascending, List<string> includes = null)
    {
        if (page == null || size == null)
            return await GetCollectionByExpressionAsync(expression);

        var query = LeaveContext.Set<T>()
            .Where(expression);

        if (orderByDirection == SortDirection.Ascending)
            query = query.OrderBy(orderBy);
        else
            query = query.OrderByDescending(orderBy);

        query = ApplyIncludes(includes, query);

        return await query.Skip((page.Value - 1) * size.Value)
            .Take(size.Value).ToListAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        => await LeaveContext.Set<T>().AnyAsync(expression);

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        => await LeaveContext.Set<T>().CountAsync(expression);

    public async Task<bool> AddAsync(T model)
    {
        LeaveContext.Set<T>().Add(model);
        return await LeaveContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddRangeAsync(List<T> models)
    {
        LeaveContext.Set<T>().AddRange(models);
        return await LeaveContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(T model)
    {
        LeaveContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return await LeaveContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(T model)
    {
        LeaveContext.Entry(model).State = EntityState.Deleted;
        return await LeaveContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteRangeAsync(List<T> models)
    {
        foreach (var model in models)
        {
            LeaveContext.Entry(model).State = EntityState.Deleted;
        }

        return await LeaveContext.SaveChangesAsync() > 0;
    }

    //public async Task<T> FindAsync(int id) => LeaveContext.Set<T>().FindAsync(id);

    public async Task<T> GetFirstOrDefaultByExpressionAsync(Expression<Func<T, bool>> expression) 
        => await LeaveContext.Set<T>().FirstOrDefaultAsync(expression);
    

    public async Task<bool> AllAsync(Expression<Func<T, bool>> expression)
        => await LeaveContext.Set<T>().AllAsync(expression);
}
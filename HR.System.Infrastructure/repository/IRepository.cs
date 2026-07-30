using System.Linq.Expressions;

namespace HR.System.Infrastructure.repository;

public interface IRepository<T>
    where T : class
{
    /// <summary>
    /// Queryable representation of the
    /// dataset that can be build upon
    /// </summary>
    Task<IQueryable<T>> Queryable();

    /// <summary>
    /// Returns a collection of records of type T
    /// </summary>
    /// <returns>Collection of T</returns>
    Task<List<T>> GetCollectionAsync();

    /// <summary>
    /// Returns a filtered collection of type T based on a specific expression criteria
    /// </summary>
    /// <param name="expression">Filter criteria</param>
    /// <param name="includes">Related entities to include in the query results</param>
    /// <returns>Collection of T matching the expression</returns>
    Task<List<T>> GetCollectionByExpressionAsync(Expression<Func<T, bool>> expression, List<string> includes = null);


    /// <summary>
    /// Creates a model of type T in the datastore
    /// </summary>
    /// <param name="model">Model to persist</param>
    /// <returns>Boolean that indicates if the operation passed</returns>
    Task<bool> AddAsync(T model);

    /// <summary>
    /// Adds a list of models to the datastore
    /// </summary>
    /// <param name="models">Models to add</param>
    /// <returns>Boolean that indicates if the operation passed</returns>
    Task<bool> AddRangeAsync(List<T> models);

    /// <summary>
    /// Todo: complete the documentation
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<bool> AllAsync(Expression<Func<T, bool>> expression);

    /// <summary>
    /// Updates an existing model in the datastore
    /// </summary>
    /// <param name="model">Model to update</param>
    /// <returns>Boolean that indicates if the operation passed</returns>
    Task<bool> UpdateAsync(T model);

    /// <summary>
    /// Deletes an existing model from the datastore
    /// </summary>
    /// <param name="model">Model to delete</param>
    /// <returns>Boolean that indicates if the operation passed</returns>
    Task<bool> DeleteAsync(T model);

    /// <summary>
    /// Deletes an existing list of models from the datastore
    /// </summary>
    /// <param name="models">Models to delete</param>
    /// <returns>Boolean that indicates if the operation passed</returns>
    Task<bool> DeleteRangeAsync(List<T> models);

    /// <summary>
    /// Returns true if a model matching the expression criteria is found in the datastore
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Boolean to indicate if a model is found</returns>
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

    /// <summary>
    /// Returns the number of records that exist for the expression in the datastore
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Number of records</returns>
    Task<int> CountAsync(Expression<Func<T, bool>> expression);

    /// <summary>
    /// Finds a model in the datastore that matches the expression criteria.
    /// Returns null if no matching model could be found
    /// </summary>
    /// <param name="id">Primary key</param>
    /// <returns>Model matching the expression or null</returns>
    //Task<T> FindAsync(int id);

    /// <summary>
    /// Returns a type T entity based on a specific expression criteria, else returns null
    /// </summary>
    /// <param name="expression">Filter criteria</param>
    /// <returns>Entity of T matching the expression or null if expression does not find a match</returns>
    Task<T> GetFirstOrDefaultByExpressionAsync(Expression<Func<T, bool>> expression);
}

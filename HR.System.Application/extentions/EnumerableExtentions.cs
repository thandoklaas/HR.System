using System.Text;

namespace HR.System.Application.extentions;

/// <summary>
/// Extentions onto IEnumerable
/// </summary>
public static class EnumerableExtentions
{
    /// <summary>
    /// Returns a paginated list based on the page and the size
    /// </summary>
    /// <typeparam name="T">Generic class</typeparam>
    /// <param name="collection">collection</param>
    /// <param name="page">page number</param>
    /// <param name="size">page size</param>
    /// <returns></returns>

#nullable enable
    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> collection, int page, int size)
        where T : class
    {
        return collection
            .Skip(page * size)
            .Take(size);
    }
}

public static class StringJoinExtensions
{
    // Lifted off https://stackoverflow.com/questions/17560201/join-liststring-together-with-commas-plus-and-for-last-element:
    public static string JoinUsingLastSeparator<T>(this IEnumerable<T> values, string separator, string lastSeparator = null)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));
        if (separator == null)
            throw new ArgumentNullException(nameof(separator));

        var sb = new StringBuilder();
        var enumerator = values.GetEnumerator();

        if (enumerator.MoveNext())
            sb.Append(enumerator.Current);

        var objectIsSet = false;
        object obj = null;
        if (enumerator.MoveNext())
        {
            obj = enumerator.Current;
            objectIsSet = true;
        }

        while (enumerator.MoveNext())
        {
            sb.Append(separator);
            sb.Append(obj);
            obj = enumerator.Current;
            objectIsSet = true;
        }

        if (!objectIsSet)
            return sb.ToString();
        sb.Append(lastSeparator ?? separator);
        sb.Append(obj);

        enumerator.Dispose();

        return sb.ToString();
    }
}

public static class QueryableExtentions
{
    /// <summary>
    /// Returns a paginated list based on the page and the size
    /// </summary>
    /// <typeparam name="T">Generic class</typeparam>
    /// <param name="collection">collection</param>
    /// <param name="page">page number</param>
    /// <param name="size">page size</param>
    /// <returns></returns>
    public static IQueryable<T> Paginate<T>(this IQueryable<T> collection, int page, int size)
        where T : class
    {
        return collection
            .Skip(page * size)
            .Take(size);
    }
}
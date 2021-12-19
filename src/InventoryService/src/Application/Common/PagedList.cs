namespace beng.OrdersService.Application.Common;

public sealed class PagedList<T>
{
    public PagedList(
        ICollection<T> items,
        int pageIndex,
        int pageSize,
        int totalCount)
    {
        Items = items;
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public ICollection<T> Items { get; private set; }
    public int PageIndex { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public int Count => Items.Count;
    public int TotalPages => ((TotalCount - 1) / PageSize) + 1;
    public bool HasPreviousPage => PageIndex > 0;
    public bool HasNextPage => (TotalPages - 1) > PageIndex;
}

public static class CollectionExtensions
{
    public static PagedList<T> TakePage<T>(
        this IQueryable<T> items,
        int pageIndex,
        int pageSize)
    {
        if (pageIndex < 0)
            pageIndex = 0;
        if (pageSize == 0)
            pageSize = 10;

        var collection = items.Skip((pageIndex) * pageSize).Take(pageSize).ToList();
        return new PagedList<T>(collection, pageIndex, pageSize, items.Count());
    }

    public static PagedList<T> TakePage<T>(
        this IQueryable<T> items,
        int pageIndex,
        int pageSize,
        int total)
    {
        if (pageIndex < 0)
            pageIndex = 0;
        if (pageSize == 0)
            pageSize = 10;

        var collection = items.Skip((pageIndex) * pageSize).Take(pageSize).ToList();
        return new PagedList<T>(collection, pageIndex, pageSize, total);
    }

    public static PagedList<T> TakePage<T>(
        this IEnumerable<T> items,
        int pageIndex,
        int pageSize)
    {
        if (pageIndex < 0)
            pageIndex = 0;
        if (pageSize == 0)
            pageSize = 10;

        var collection = items.Skip((pageIndex) * pageSize).Take(pageSize).ToList();
        return new PagedList<T>(collection, pageIndex, pageSize, items.Count());
    }

    public static PagedList<T> TakePage<T>(
        this IEnumerable<T> items,
        int pageIndex,
        int pageSize,
        int total)
    {
        if (pageIndex < 0)
            pageIndex = 0;
        if (pageSize == 0)
            pageSize = 10;

        var collection = items.Skip((pageIndex) * pageSize).Take(pageSize).ToList();
        return new PagedList<T>(collection, pageIndex, pageSize, total);
    }
}
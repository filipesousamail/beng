using System.Collections;

namespace beng.OrdersService.Application.Common;

public interface IPagedResult
{
    ICollection Items { get; }
    int Count { get; }
    int PageIndex { get; }
    int PageSize { get; }
    int TotalCount { get; }
    int TotalPages { get; }
    bool HasPreviousPage { get; }
    bool HasNextPage { get; }
}

public interface IPagedResult<T> : IPagedResult
{
    new ICollection<T> Items { get; }
}
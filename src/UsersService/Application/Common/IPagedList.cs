using System.Collections;

namespace beng.UsersService.Application.Common;

public interface IPagedList
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

public interface IPagedList<T> : IPagedList
{
    new ICollection<T> Items { get; }
}
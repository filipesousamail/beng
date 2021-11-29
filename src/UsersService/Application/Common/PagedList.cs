using System.Collections;

namespace beng.UsersService.Application.Common
{
    public sealed class PagedList<T> : IPagedList<T>
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

        public int Count
        {
            get { return Items.Count; }
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public int TotalPages
        {
            get { return ((TotalCount - 1) / PageSize) + 1; }
        }

        public bool HasPreviousPage
        {
            get { return PageIndex > 0; }
        }

        public bool HasNextPage
        {
            get { return (TotalPages - 1) > PageIndex; }
        }

        ICollection IPagedList.Items
        {
            get { return (ICollection) Items; }
        }
    }

    public static class CollectionExtensions
    {
        public static IPagedList<T> TakePage<T>(
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

        public static IPagedList<T> TakePage<T>(
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

        public static IPagedList<T> TakePage<T>(
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

        public static IPagedList<T> TakePage<T>(
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
}
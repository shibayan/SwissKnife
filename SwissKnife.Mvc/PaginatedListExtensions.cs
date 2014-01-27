using System;
using System.Collections.Generic;
using System.Linq;

namespace SwissKnife.Mvc
{
    public static class PaginatedListExtensions
    {
        public static PaginatedList<TSource> ToPaginatedList<TSource>(this IEnumerable<TSource> source, int pageIndex, int pageSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException("pageIndex");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("pageSize");
            }

            var start = (pageIndex - 1) * pageSize;
            var totalCount = source.Count();

            return new PaginatedList<TSource>(source.Skip(start).Take(pageSize), pageIndex, pageSize, totalCount);
        }

        public static PaginatedList<TSource> ToPaginatedList<TSource>(this IQueryable<TSource> source, int pageIndex, int pageSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException("pageIndex");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("pageSize");
            }

            var start = (pageIndex - 1) * pageSize;
            var totalCount = source.Count();

            return new PaginatedList<TSource>(source.Skip(start).Take(pageSize), pageIndex, pageSize, totalCount);
        }
    }
}

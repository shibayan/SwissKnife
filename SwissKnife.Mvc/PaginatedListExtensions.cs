using System;
using System.Collections.Generic;
using System.Linq;

namespace SwissKnife.Mvc
{
    public static class PaginatedListExtensions
    {
        public static PaginatedList<TSource> ToPaginatedList<TSource>(this IEnumerable<TSource> source, int page, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (page < 1)
            {
                throw new ArgumentOutOfRangeException("page");
            }

            if (count < 1)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            var start = (page - 1) * count;
            var totalCount = source.Count();

            return new PaginatedList<TSource>(source.Skip(start).Take(count), page, count, totalCount);
        }

        public static PaginatedList<TSource> ToPaginatedList<TSource>(this IQueryable<TSource> source, int page, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (page < 1)
            {
                throw new ArgumentOutOfRangeException("page");
            }

            if (count < 1)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            var start = (page - 1) * count;
            var totalCount = source.Count();

            return new PaginatedList<TSource>(source.Skip(start).Take(count), page, count, totalCount);
        }
    }
}

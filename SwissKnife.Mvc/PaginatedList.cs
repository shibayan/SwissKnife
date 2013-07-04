using System.Collections.Generic;

namespace SwissKnife.Mvc
{
    public class PaginatedList<T> : List<T>, IPaginatedList
    {
        public PaginatedList(IEnumerable<T> collection, int pageIndex, int pageCount, int totalCount)
            : base(collection)
        {
            PageIndex = pageIndex;
            PageCount = pageCount;
            TotalCount = totalCount;
        }

        public int PageIndex { get; private set; }

        public int PageCount { get; private set; }

        public int TotalCount { get; private set; }
    }
}

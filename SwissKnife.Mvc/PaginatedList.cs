using System.Collections.Generic;

namespace SwissKnife.Mvc
{
    public class PaginatedList<T> : List<T>, IPaginatedList<T>
    {
        public PaginatedList(IEnumerable<T> collection, int pageIndex, int pageSize, int totalCount)
            : base(collection)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }
    }
}

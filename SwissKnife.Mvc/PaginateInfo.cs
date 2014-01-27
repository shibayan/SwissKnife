using System;
using System.Collections.Generic;
using System.Linq;

namespace SwissKnife.Mvc
{
    public class PaginateInfo
    {
        public PaginateInfo(IPaginatedList list)
            : this(list.PageIndex, list.PageSize, list.TotalCount)
        {
        }

        public PaginateInfo(int pageIndex, int pageSize, int totalCount)
        {
            WindowSize = 2;

            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;

            PageCount = TotalCount == 0 ? 1 : (int)Math.Ceiling((double)TotalCount / PageSize);

            StartIndex = (PageIndex - 1) * PageSize + 1;
            EndIndex = TotalCount > PageIndex * PageSize ? PageIndex * PageSize : TotalCount;
        }

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int PageCount { get; private set; }

        public int WindowSize { get; private set; }

        public int StartIndex { get; private set; }

        public int EndIndex { get; private set; }

        public int TotalCount { get; private set; }

        public bool HasPreviousPage
        {
            get { return PageIndex > 1; }
        }

        public bool HasNextPage
        {
            get { return PageIndex < PageCount; }
        }

        public int PreviousPage
        {
            get { return HasPreviousPage ? PageIndex - 1 : 1; }
        }

        public int NextPage
        {
            get { return HasNextPage ? PageIndex + 1 : PageCount; }
        }

        public IEnumerable<int> PageNumbers
        {
            get
            {
                const int start = 1;
                var end = PageCount;

                var windowSize = WindowSize * 2 + 1 > PageCount ? PageCount : WindowSize * 2 + 1;

                int index;

                var startIndex = PageIndex - WindowSize;
                var endIndex = PageIndex + WindowSize;

                if (start > startIndex)
                {
                    index = 1;
                }
                else if (endIndex > end)
                {
                    index = end - windowSize + 1;
                }
                else
                {
                    index = startIndex;
                }

                return Enumerable.Range(index, windowSize);
            }
        }
    }
}

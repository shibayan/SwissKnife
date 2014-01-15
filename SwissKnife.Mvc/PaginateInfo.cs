using System;
using System.Collections.Generic;
using System.Linq;

namespace SwissKnife.Mvc
{
    public class PaginateInfo
    {
        public PaginateInfo(IPaginatedList list)
            : this(list.PageIndex, list.PageCount, list.TotalCount)
        {
        }

        public PaginateInfo(int pageIndex, int pageCount, int totalCount)
        {
            WindowSize = 5;

            PageIndex = pageIndex;
            PageCount = pageCount;
            TotalCount = totalCount;

            TotalPage = TotalCount == 0 ? 1 : (int)Math.Ceiling((double)TotalCount / PageCount);

            StartIndex = (PageIndex - 1) * PageCount + 1;
            EndIndex = TotalCount > PageIndex * PageCount ? PageIndex * PageCount : TotalCount;
        }

        public int PageIndex { get; private set; }

        public int PageCount { get; private set; }

        public int TotalCount { get; private set; }

        public int WindowSize { get; private set; }

        public int TotalPage { get; private set; }

        public int StartIndex { get; private set; }

        public int EndIndex { get; private set; }

        public bool HasPreviousPage
        {
            get { return PageIndex > 1; }
        }

        public bool HasNextPage
        {
            get { return PageIndex < TotalPage; }
        }

        public int PreviousPage
        {
            get { return HasPreviousPage ? PageIndex - 1 : 1; }
        }

        public int NextPage
        {
            get { return HasNextPage ? PageIndex + 1 : TotalPage; }
        }

        public IEnumerable<int> PageNumbers
        {
            get
            {
                const int start = 1;
                var end = TotalPage;

                var windowSize = WindowSize > TotalPage ? TotalPage : WindowSize;

                var windowHalf = windowSize / 2;

                int index;

                var startIndex = PageIndex - windowHalf;
                var endIndex = PageIndex + windowHalf;

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

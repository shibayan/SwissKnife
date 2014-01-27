using System.Collections.Generic;

namespace SwissKnife.Mvc
{
    public interface IPaginatedList
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
    }

    public interface IPaginatedList<T> : IList<T>, IPaginatedList
    {
    }
}

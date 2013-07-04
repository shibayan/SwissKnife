namespace SwissKnife.Mvc
{
    public interface IPaginatedList
    {
        int PageIndex { get; }
        int PageCount { get; }
        int TotalCount { get; }
    }
}

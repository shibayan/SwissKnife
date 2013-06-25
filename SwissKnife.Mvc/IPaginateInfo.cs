namespace SwissKnife.Mvc
{
    public interface IPaginateInfo
    {
        int PageIndex { get; }

        int PageCount { get; }

        int TotalCount { get; }
    }
}

namespace Common.Pagination;

public class PaginateResult<T>
{
    public required int PageSize { get; set; }
    public required int PageIndex { get; set; }
    public required int Count { get; set; }
    public required IList<T> Data { get; set; }

    public PaginateResult<TD> MapTo<TD>(Func<T, TD> mapper)
    {
        return new PaginateResult<TD>
        {
            PageSize = PageSize,
            PageIndex = PageIndex,
            Count = Count,
            Data = Data.Select(mapper).ToList()
        };
    }
}
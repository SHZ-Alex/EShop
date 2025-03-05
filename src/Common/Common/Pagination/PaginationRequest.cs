using System.ComponentModel.DataAnnotations;

namespace Common.Pagination;

public record PaginationRecordRequest : IPagination
{
    [Range(1, int.MaxValue, ErrorMessage = "PageIndex can't be smaller then 1.")]
    public required int PageIndex { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "PageSize can't be smaller then 1.")]
    public required int PageSize { get; set; }
}

public class PaginationRequest : IPagination
{
    [Range(1, int.MaxValue, ErrorMessage = "PageIndex can't be smaller then 1.")]
    public required int PageIndex { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "PageSize can't be smaller then 1.")]
    public required int PageSize { get; set; }
}

public interface IPagination
{
    
    public int PageIndex { get; set; }

    public int PageSize { get; set; }
}
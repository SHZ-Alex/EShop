using Common.Pagination;
using Ordering.Application.Orders.Queries.GetAll;

namespace Ordering.API.Contracts.Requests;

public record GetAllOrdersRequest : PaginationRecordRequest
{
    public static GetAllOrdersQuery MapFrom(GetAllOrdersRequest request)
        => new()
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
        };
}
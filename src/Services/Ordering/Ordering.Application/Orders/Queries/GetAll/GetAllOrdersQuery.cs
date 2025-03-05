using Common.CQRS;
using Common.Pagination;

namespace Ordering.Application.Orders.Queries.GetAll;

public record GetAllOrdersQuery : PaginationRecordRequest, IQuery<GetAllOrdersResponse>;
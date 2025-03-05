using Common.Pagination;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetAll;

public record GetAllOrdersResponse(PaginateResult<OrderDto> Orders);
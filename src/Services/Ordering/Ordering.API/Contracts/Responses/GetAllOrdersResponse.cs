using Common.Pagination;
using Ordering.Application.Dtos;

namespace Ordering.API.Contracts.Responses;

public record GetAllOrdersResponse(PaginateResult<OrderDto> Orders);
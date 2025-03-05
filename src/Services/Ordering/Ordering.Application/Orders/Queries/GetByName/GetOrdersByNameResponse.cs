using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetByName;

public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);
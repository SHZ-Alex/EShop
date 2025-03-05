using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetByCustomer;

public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
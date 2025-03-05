using Ordering.Application.Dtos;

namespace Ordering.API.Contracts.Requests;

public record CreateOrderRequest(OrderDto OrderDto);
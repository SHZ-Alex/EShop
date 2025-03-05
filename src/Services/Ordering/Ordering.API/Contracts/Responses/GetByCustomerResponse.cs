using Ordering.Application.Dtos;

namespace Ordering.API.Contracts.Responses;

public record GetByCustomerResponse(IEnumerable<OrderDto> Orders);
using Ordering.Application.Dtos;

namespace Ordering.API.Contracts.Responses;

public record GetByNameResponse(IEnumerable<OrderDto> Orders);
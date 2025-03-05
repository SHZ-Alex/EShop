using Common.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetByName;

public record GetOrdersByNameQuery(string Name) : IQuery<GetOrdersByNameResponse>;
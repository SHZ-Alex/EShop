using Common.CQRS;
using Ordering.Application.Dtos;
using Ordering.Application.Interfaces.Database;

namespace Ordering.Application.Orders.Queries.GetByName;

public class GetOrdersByNameQueryHandler(IOrderDatabaseRepository orderDatabaseRepository) 
    : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResponse>
{
    public async Task<GetOrdersByNameResponse> Handle(GetOrdersByNameQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderDatabaseRepository.GetOrdersByName(request.Name, cancellationToken);
        return new GetOrdersByNameResponse(orders.Select(OrderDto.MapFromOrder));
    }
}
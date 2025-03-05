using Common.CQRS;
using Ordering.Application.Dtos;
using Ordering.Application.Interfaces.Database;

namespace Ordering.Application.Orders.Queries.GetAll;

public class GetAllOrdersQueryHandler(IOrderDatabaseRepository orderDatabaseRepository) : IQueryHandler<GetAllOrdersQuery, GetAllOrdersResponse>
{
    public async Task<GetAllOrdersResponse> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderDatabaseRepository.GetOrdersAsync(request, cancellationToken);
        return new GetAllOrdersResponse(orders.MapTo(OrderDto.MapFromOrder));
    }
}
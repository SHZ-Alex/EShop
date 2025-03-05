using Common.CQRS;
using Ordering.Application.Dtos;
using Ordering.Application.Interfaces.Database;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.Queries.GetByCustomer;

public class GetOrdersByCustomerQueryHandler(IOrderDatabaseRepository orderDatabaseRepository) 
    : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResponse>
{
    public async Task<GetOrdersByCustomerResponse> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderDatabaseRepository.GetOrdersByCustomerId(new CustomerId(request.CustomerId), cancellationToken);
        return new GetOrdersByCustomerResponse(orders.Select(OrderDto.MapFromOrder));
    }
}
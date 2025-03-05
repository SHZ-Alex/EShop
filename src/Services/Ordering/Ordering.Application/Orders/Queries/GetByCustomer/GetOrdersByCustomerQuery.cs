using Common.CQRS;

namespace Ordering.Application.Orders.Queries.GetByCustomer;

public record GetOrdersByCustomerQuery(Guid CustomerId) : IQuery<GetOrdersByCustomerResponse>;
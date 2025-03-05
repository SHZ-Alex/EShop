using Common.Pagination;
using Ordering.Domain.Entities;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Interfaces.Database;

public interface IOrderDatabaseRepository
{
    Task<PaginateResult<Order>> GetOrdersAsync(IPagination request, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetOrdersByName(string name, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetOrdersByCustomerId(CustomerId id, CancellationToken cancellationToken);
    Task<Order?> GetByIdAsync(OrderId id, CancellationToken cancellationToken);
    Task Create(Order order, CancellationToken cancellationToken);
    Task Update(Order order, CancellationToken cancellationToken);
    Task<bool> Delete(OrderId id, CancellationToken cancellationToken);
}
using Common.Pagination;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Interfaces.Database;
using Ordering.Domain.Entities;
using Ordering.Domain.ValueObjects;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure.Repositories;

public class OrderDatabaseRepository(ApplicationDbContext dbContext) : IOrderDatabaseRepository
{
    public async Task<PaginateResult<Order>> GetOrdersAsync(IPagination request, CancellationToken cancellationToken)
    {
        return await dbContext.Orders.AsNoTracking()
            .Include(x => x.OrderItems)
            .Paginate(request, cancellationToken);
    }

    public async Task<IEnumerable<Order>> GetOrdersByName(string name, CancellationToken cancellationToken)
    {
        return await dbContext.Orders.AsNoTracking()
            .Include(o => o.OrderItems)
            .Where(x => x.OrderName.Value.Contains(name))
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerId(CustomerId id, CancellationToken cancellationToken)
    {
        return await dbContext.Orders.AsNoTracking()
            .Include(o => o.OrderItems)
            .Where(x => x.CustomerId == id)
            .ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(OrderId id, CancellationToken cancellationToken)
        => await dbContext.Orders.FindAsync([id], cancellationToken);

    public async Task Create(Order order, CancellationToken cancellationToken)
    {
        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Order order, CancellationToken cancellationToken)
    {
        dbContext.Orders.Update(order);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> Delete(OrderId id, CancellationToken cancellationToken)
    {
        return await dbContext.Orders
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync(cancellationToken) == 1;
    }
}
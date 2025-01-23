using Basket.API.Data;
using Basket.API.Models;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Basket.API.Repositories;

public class BasketRepository(BasketDbContext dbContext) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken)
    {
        var basket = await dbContext.ShoppingCarts
            .AsNoTracking()
            .Include(x => x.Items)
            .Where(x => x.UserName == userName)
            .FirstOrDefaultAsync(cancellationToken);

        return basket ?? throw new NotFoundException();
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken)
    {
        dbContext.ShoppingCarts.Add(basket);
        await dbContext.SaveChangesAsync(cancellationToken);
        return basket;
    }

    public async Task DeleteBasket(string userName, CancellationToken cancellationToken)
    {
        var count = await dbContext.ShoppingCarts
            .Where(x => x.UserName == userName)
            .ExecuteDeleteAsync(cancellationToken);
        
        if (count == 0)
            throw new NotFoundException();
    }
}
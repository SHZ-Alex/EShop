using Basket.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.API.Data;

public class BasketDbContext(DbContextOptions<BasketDbContext> options) : DbContext(options)
{
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
}
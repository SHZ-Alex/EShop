using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Basket.API.Models;

[Owned]
public class ShoppingCartItem
{
    public required int Quantity { get; set; }
    public required string Color { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public required decimal Price { get; set; }
    public required long ProductId { get; set; }
    public required string ProductName { get; set; }
}
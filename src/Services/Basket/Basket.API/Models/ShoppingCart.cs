using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.API.Models;

public class ShoppingCart
{
    [Key]
    public required long Id { get; set; }
    public required string UserName { get; set; }
    public required IList<ShoppingCartItem> Items { get; set; }
    
    [NotMapped]
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
}
namespace Discount.Grpc.Models;

public class Coupon
{
    public required long Id { get; set; }
    public required string ProductName { get; set; }
    public required string Description { get; set; }
    public required int Amount { get; set; }
}
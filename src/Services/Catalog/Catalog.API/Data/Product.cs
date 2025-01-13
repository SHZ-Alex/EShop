namespace Catalog.API.Data;

public class Product
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required List<string> Category { get; set; } = [];
    public required string Description { get; set; }
    public required string ImagePath { get; set; }
    public required decimal Price { get; set; }
}
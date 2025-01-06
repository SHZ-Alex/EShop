namespace Catalog.API.Products.Create.Endpoint;

public record CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImagePath,
    decimal Price);
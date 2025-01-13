namespace Catalog.API.Endpoints.Products.Post;

public record PostProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImagePath,
    decimal Price);
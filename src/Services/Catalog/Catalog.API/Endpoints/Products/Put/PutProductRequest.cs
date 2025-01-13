namespace Catalog.API.Endpoints.Products.Put;

public record PutProductRequest(long Id, string Name, 
    List<string> Category, string Description, 
    string ImagePath, decimal Price);
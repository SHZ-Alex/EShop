using Common.CQRS;

namespace Catalog.API.Products.Create;

public record CreateProductCommand(string Name, 
    List<string> Category, string Description, 
    string ImagePath, decimal Price) : ICommand<CreateProductCommandResult>;
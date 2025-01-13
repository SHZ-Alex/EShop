using Common.CQRS;

namespace Catalog.API.Products.Update;

public record UpdateProductCommand(long Id, string Name, 
    List<string> Category, string Description, 
    string ImagePath, decimal Price) : ICommand;
using Common.CQRS;

namespace Catalog.API.Products.Delete;

public record DeleteProductCommand(long Id) : ICommand;
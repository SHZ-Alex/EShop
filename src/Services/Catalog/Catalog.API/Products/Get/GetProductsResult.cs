using Catalog.API.Data;

namespace Catalog.API.Products.Get;

public record GetProductsResult(IEnumerable<Product> Products);
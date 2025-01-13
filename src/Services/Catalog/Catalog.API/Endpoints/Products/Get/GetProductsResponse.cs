using Catalog.API.Data;

namespace Catalog.API.Endpoints.Products.Get;

public record GetProductsResponse(IEnumerable<Product> Products);
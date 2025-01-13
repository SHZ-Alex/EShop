using Catalog.API.Data;

namespace Catalog.API.Endpoints.Products.GetByCategory;

public record GetByCategoryProductsResponse(IEnumerable<Product> Products);
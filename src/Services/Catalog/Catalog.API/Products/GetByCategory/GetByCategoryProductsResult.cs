using Catalog.API.Data;

namespace Catalog.API.Products.GetByCategory;

public record GetByCategoryProductsResult(IEnumerable<Product> Products);
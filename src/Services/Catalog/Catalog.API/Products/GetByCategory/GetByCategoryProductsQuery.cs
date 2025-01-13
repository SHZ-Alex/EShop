using Common.CQRS;

namespace Catalog.API.Products.GetByCategory;

public record GetByCategoryProductsQuery(string Category) : IQuery<GetByCategoryProductsResult>;
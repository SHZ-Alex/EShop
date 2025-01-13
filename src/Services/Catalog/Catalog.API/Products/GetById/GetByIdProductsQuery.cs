using Common.CQRS;

namespace Catalog.API.Products.GetById;

public record GetByIdProductsQuery(long Id) : IQuery<GetByIdProductsResult>;
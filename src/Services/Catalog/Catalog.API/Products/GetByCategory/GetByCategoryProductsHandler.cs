using Catalog.API.Data;
using Common.CQRS;
using Marten;

namespace Catalog.API.Products.GetByCategory;

public class GetByCategoryProductsHandler(IDocumentSession session) : IQueryHandler<GetByCategoryProductsQuery, GetByCategoryProductsResult>
{
    public async Task<GetByCategoryProductsResult> Handle(GetByCategoryProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(x => x.Category.Contains(request.Category))
            .ToListAsync(cancellationToken);
        
        return new GetByCategoryProductsResult(products);
    }
}
using Catalog.API.Data;
using Common.CQRS;
using Marten;
using Marten.Pagination;

namespace Catalog.API.Products.Get;

public class GetProductsHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return new GetProductsResult(products);
    }
}
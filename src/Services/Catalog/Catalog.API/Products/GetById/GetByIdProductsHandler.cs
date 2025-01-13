using Catalog.API.Data;
using Common.CQRS;
using Common.Exceptions;
using Marten;

namespace Catalog.API.Products.GetById;

public class GetByIdProductsHandler(IDocumentSession session) : IQueryHandler<GetByIdProductsQuery, GetByIdProductsResult>
{
    public async Task<GetByIdProductsResult> Handle(GetByIdProductsQuery request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException();
        
        return new GetByIdProductsResult(product);
    }
}
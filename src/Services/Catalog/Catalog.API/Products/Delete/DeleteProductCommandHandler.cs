using Catalog.API.Data;
using Common.CQRS;
using Marten;
using MediatR;

namespace Catalog.API.Products.Delete;

public class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        session.Delete<Product>(request.Id);
        await session.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
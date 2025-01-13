using Catalog.API.Data;
using Common.CQRS;
using Common.Exceptions;
using Marten;
using MediatR;

namespace Catalog.API.Products.Update;

public class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException();
        
        product.Name = request.Name;
        product.Category = request.Category;
        product.Description = request.Description;
        product.ImagePath = request.ImagePath;
        product.Price = request.Price;
        
        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
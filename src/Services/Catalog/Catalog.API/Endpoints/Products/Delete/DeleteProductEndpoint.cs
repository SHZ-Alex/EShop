using Carter;
using Catalog.API.Endpoints.Products.Post;
using Catalog.API.Products.Delete;
using MediatR;

namespace Catalog.API.Endpoints.Products.Delete;

public class DeleteProductEndpoint  : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id:long}", async (long id, ISender mediator) =>
            {
                await mediator.Send(new DeleteProductCommand(id));
                return Results.NoContent();
            })
            .WithName("DeleteProduct")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete product")
            .WithDescription("Delete product");
    }
}
using Carter;
using Catalog.API.Endpoints.Products.Post;
using Catalog.API.Products.Update;
using Mapster;
using MediatR;

namespace Catalog.API.Endpoints.Products.Put;

public class PutProductEndpoint  : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (PutProductRequest request, ISender mediator) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                await mediator.Send(command);
                
                return Results.NoContent();
            })
            .WithName("UpdateProduct")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update product")
            .WithDescription("Update product");
    }
}
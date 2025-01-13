using Carter;
using Catalog.API.Products.Create;
using Mapster;
using MediatR;

namespace Catalog.API.Endpoints.Products.Post;

public class PostProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (PostProductRequest request, ISender mediator) =>
        {
            var command = request.Adapt<CreateProductCommand>();
            var result = await mediator.Send(command);
            
            var response = new PostProductResponse(result.Id);
            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<PostProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Creates a new product")
        .WithDescription("Creates a new product");
    }
}
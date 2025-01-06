using Carter;
using Mapster;
using MediatR;

namespace Catalog.API.Products.Create.Endpoint;

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender mediator) =>
        {
            var command = request.Adapt<CreateProductCommand>();
            var result = await mediator.Send(command);
            
            var response = new CreateProductResponse(result.Id);
            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Creates a new product")
        .WithDescription("Creates a new product");
    }
}
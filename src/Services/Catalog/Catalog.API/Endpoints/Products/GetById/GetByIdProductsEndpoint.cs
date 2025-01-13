using Carter;
using Catalog.API.Products.GetById;
using MediatR;

namespace Catalog.API.Endpoints.Products.GetById;

public class GetByIdProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id:long}", async (ISender mediator, long id) =>
            {
                var result = await mediator.Send(new GetByIdProductsQuery(id));
                
                var response = new GetByIdProductsResponse(result.Product);
                
                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetByIdProductsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest) 
            .WithSummary("Get products by id")
            .WithDescription("Get products by id");
    }
}
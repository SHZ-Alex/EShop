using Carter;
using Catalog.API.Products.GetByCategory;
using MediatR;

namespace Catalog.API.Endpoints.Products.GetByCategory;

public class GetByCategoryProductsEndpoint  : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{id}", async (ISender mediator, string id) =>
            {
                var result = await mediator.Send(new GetByCategoryProductsQuery(id));
                
                var response = new GetByCategoryProductsResponse(result.Products);
                
                return Results.Ok(response);
            })
            .WithName("GetProductByCategory")
            .Produces<GetByCategoryProductsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest) 
            .WithSummary("Get products by category")
            .WithDescription("Get products by category");
    }
}
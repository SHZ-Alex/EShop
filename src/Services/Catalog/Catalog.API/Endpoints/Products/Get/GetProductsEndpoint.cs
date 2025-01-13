using Carter;
using Catalog.API.Endpoints.Products.Post;
using Catalog.API.Products.Get;
using MediatR;

namespace Catalog.API.Endpoints.Products.Get;

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender mediator) =>
            {
                var query = new GetProductsQuery(request.PageNumber!.Value, request.PageSize!.Value); 
                var result = await mediator.Send(query);
                
                var response = new GetProductsResponse(result.Products);
                
                return Results.Ok(response);
            })
            .WithName("GetProduct")
            .Produces<GetProductsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest) 
            .WithSummary("Get products")
            .WithDescription("Get products");
    }
}
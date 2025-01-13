namespace Catalog.API.Endpoints.Products.Get;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
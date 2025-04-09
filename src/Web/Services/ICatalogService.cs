using Refit;
using Web.Models.Catalog;

namespace Web.Services;

public interface ICatalogService
{
    [Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
    Task<GetProductsResponse> GetProducts(int? pageNumber = 1, int? pageSize = 10);
    
    [Get("/catalog-service/products/{id}")]
    Task<GetProductByIdResponse> GetProduct(long id);
    
    [Get("/catalog-service/products/category/{category}")]
    Task<GetProductByCategoryResponse> GetProductsByCategory(string category);
}

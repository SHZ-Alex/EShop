using Marten;
using Marten.Schema;

namespace Catalog.API.Data.InitialData;

public class ProductInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        await using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation))
            return;
        
        session.Store(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private IEnumerable<Product> GetPreconfiguredProducts()
    {
        return
        [
            new Product
            {
                Id = 1,
                Name = "IPhone 16",
                Category = ["Phones", "Electronics"],
                Description = "This iphone",
                ImagePath = "product1.webp",
                Price = 950M
            },
            new Product
            {
                Id = 2,
                Name = "IPhone 16 PRO",
                Category = ["Phones", "Electronics"],
                Description = "This iphone 16",
                ImagePath = "product2.webp",
                Price = 960M
            }
        ];
    }
}
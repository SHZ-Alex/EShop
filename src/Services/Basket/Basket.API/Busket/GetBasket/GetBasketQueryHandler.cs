using Basket.API.Models;
using Basket.API.Repositories;
using Common.CQRS;

namespace Basket.API.Busket.GetBasket;

public class GetBasketQueryHandler(IBasketRepository basketRepository) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetBasket(request.UserName, cancellationToken);

        return new GetBasketResult(new ShoppingCart
        {
            Id = 5,
            UserName = "awd",
            Items = new List<ShoppingCartItem>()
        });
    }
}
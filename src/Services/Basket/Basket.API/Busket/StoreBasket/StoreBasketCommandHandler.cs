using Basket.API.Repositories;
using Common.CQRS;
using MediatR;

namespace Basket.API.Busket.StoreBasket;

public class StoreBasketCommandHandler(IBasketRepository basketRepository) : ICommandHandler<StoreBasketCommand>
{
    public async Task<Unit> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        // TODO: Cashe
        await basketRepository.StoreBasket(request.Cart, cancellationToken);
        
        return new Unit();
    }
}
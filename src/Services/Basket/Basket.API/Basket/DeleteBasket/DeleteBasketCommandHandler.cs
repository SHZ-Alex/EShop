using Basket.API.Repositories;
using Common.CQRS;
using MediatR;

namespace Basket.API.Basket.DeleteBasket;

public class DeleteBasketCommandHandler(IBasketRepository basketRepository) : ICommandHandler<DeleteBasketCommand>
{
    public async Task<Unit> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        await basketRepository.DeleteBasket(request.UserName, cancellationToken);
        return new Unit();
    }
}
using Basket.API.Repositories;
using Common.CQRS;
using Discount.Grpc;
using Grpc.Core;
using MediatR;

namespace Basket.API.Basket.StoreBasket;

public class StoreBasketCommandHandler(IBasketRepository basketRepository,
    DiscountProtoService.DiscountProtoServiceClient discountProto) : ICommandHandler<StoreBasketCommand>
{
    public async Task<Unit> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        await DeductDiscount(request, cancellationToken);
        await basketRepository.StoreBasket(request.Cart, cancellationToken);
        
        return new Unit();
    }

    private async Task DeductDiscount(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        foreach (var item in request.Cart.Items)
        {
            try
            {
                var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest
                {
                    ProductName = item.ProductName
                }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
            catch (RpcException ex)
            {
                if (ex.Status.StatusCode == StatusCode.NotFound)
                    continue;

                throw;
            }
        }
    }
}
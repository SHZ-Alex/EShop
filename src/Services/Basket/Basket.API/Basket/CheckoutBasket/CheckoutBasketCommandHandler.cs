using Basket.API.Repositories;
using Common.CQRS;
using Common.Messaging.Events;
using MassTransit;
using MediatR;

namespace Basket.API.Basket.CheckoutBasket;

public class CheckoutBasketCommandHandler(IBasketRepository basketRepository,
    IPublishEndpoint publishEndpoint) : ICommandHandler<CheckoutBasketCommand>
{
    public async Task<Unit> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetBasket(request.Dto.UserName, cancellationToken);

        var eventMessage = new BasketCheckoutEvent
        {
            UserName = request.Dto.UserName,
            CustomerId = request.Dto.CustomerId,
            TotalPrice = request.Dto.TotalPrice,
            FirstName = request.Dto.FirstName,
            LastName = request.Dto.LastName,
            EmailAddress = request.Dto.EmailAddress,
            AddressLine = request.Dto.AddressLine,
            Country = request.Dto.Country,
            State = request.Dto.State,
            ZipCode = request.Dto.ZipCode,
            CardNumber = request.Dto.CardNumber,
            CardName = request.Dto.CardName,
            Expiration = request.Dto.Expiration,
            PaymentMethod = request.Dto.PaymentMethod,
            CVV = request.Dto.CVV,
            Id = Guid.NewGuid(),
            Date = DateTimeOffset.Now,
            EventType = nameof(BasketCheckoutEvent)
        };
        
        await publishEndpoint.Publish(eventMessage, cancellationToken);
        await basketRepository.DeleteBasket(request.Dto.UserName, cancellationToken);
        
        return Unit.Value;
    }
}
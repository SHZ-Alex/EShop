using Common.CQRS;

namespace Basket.API.Busket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
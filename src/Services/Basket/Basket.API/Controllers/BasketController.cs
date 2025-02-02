using Basket.API.Basket.DeleteBasket;
using Basket.API.Basket.GetBasket;
using Basket.API.Basket.StoreBasket;
using Basket.API.Controllers.Contracts.Requests;
using Basket.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

public class BasketController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetBasketResult>> GetBasket([FromQuery] GetBasketQuery query)
    {
        return await sender.Send(query);
    }

    [HttpDelete("{userName}")]
    public async Task<IActionResult> DeleteBasket(string userName)
    {
        await sender.Send(new DeleteBasketCommand(userName));
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBasket([FromBody] StoreBasketRequest request)
    {
        var command = new StoreBasketCommand(new ShoppingCart
        {
            Id = 0,
            UserName = request.UserName,
            Items = request.Items
        });
        
        await sender.Send(command);
        return Ok();
    }
}
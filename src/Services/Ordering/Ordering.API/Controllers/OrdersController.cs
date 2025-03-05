using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.API.Contracts.Requests;
using Ordering.API.Contracts.Responses;
using Ordering.Application.Orders.Commands.Create;
using Ordering.Application.Orders.Commands.Delete;
using Ordering.Application.Orders.Commands.Update;
using Ordering.Application.Orders.Queries.GetByCustomer;
using Ordering.Application.Orders.Queries.GetByName;
using GetAllOrdersResponse = Ordering.API.Contracts.Responses.GetAllOrdersResponse;

namespace Ordering.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<ActionResult<GetAllOrdersResponse>> GetOrders([FromQuery] GetAllOrdersRequest request)
    {
        var query = GetAllOrdersRequest.MapFrom(request);
        var orders = await sender.Send(query);
        return Ok(new GetAllOrdersResponse(orders.Orders));
    }
    
    [HttpGet("/customer/{customerId:guid}")]
    public async Task<ActionResult<GetByCustomerResponse>> GetOrders(Guid customerId)
    {
        var query = new GetOrdersByCustomerQuery(customerId);
        var orders = await sender.Send(query);
        return Ok(new GetByCustomerResponse(orders.Orders));
    }
    
    [HttpGet("name/{name}")]
    public async Task<ActionResult<GetByNameResponse>> GetOrders(string name)
    {
        var query = new GetOrdersByNameQuery(name);
        var orders = await sender.Send(query);
        return Ok(new GetByNameResponse(orders.Orders));
    }
    
    [HttpDelete("{orderId:guid}")]
    public async Task<IActionResult> DeleteOrder(Guid orderId)
    {
        var command = new DeleteOrderCommand(orderId);
        await sender.Send(command);
        return Ok();
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> PostOrder([FromBody] CreateOrderRequest request)
    {
        var command = new CreateOrderCommand(request.OrderDto);
        var response = await sender.Send(command);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderRequest request)
    {
        var command = new UpdateOrderCommand(request.OrderDto);
        await sender.Send(command);
        return Ok();
    }
}
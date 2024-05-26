using AlbaPizzaApp.Application.Exceptions;
using AlbaPizzaApp.Application.Orders.CancelOrder;
using AlbaPizzaApp.Application.Orders.ConfirmOrder;
using AlbaPizzaApp.Application.Orders.GetOrder;
using AlbaPizzaApp.Application.Orders.GetOrders;
using AlbaPizzaApp.Application.Orders.GetOrdersByCustomer;
using AlbaPizzaApp.Application.Orders.RegisterOrder;
using AlbaPizzaApp.Application.Orders.UpdateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlbaPizzaApp.API.Controllers.Orders;
[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;

    public OrdersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders(CancellationToken cancellationToken)
    {
        var query = new GetOrdersQuery();
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetOrderByIdQuery(id);
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("by-customer/{customerId:guid}")]
    public async Task<IActionResult> GetOrdersByCustomerId(Guid customerId, CancellationToken cancellationToken)
    {
        var query = new GetOrdersByCustomerIdQuery(customerId);
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterOrder(RegisterOrderRequest request, CancellationToken cancellationToken)
    {
        var orderDetails = request.OrderDetails.Select(detail =>
            new OrderDetailCommand(detail.ProductId, detail.TaxType, detail.Quantity, detail.UnitPrice)).ToList();

        var command = new RegisterOrderCommand(request.CustomerId, request.AddressId, request.OrderDate, orderDetails);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : throw new ResultException(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrder(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        var orderDetails = request.OrderDetails.Select(detail =>
            new OrderDetailCommand(detail.ProductId, detail.TaxType, detail.Quantity, detail.UnitPrice)).ToList();

        var command = new UpdateOrderCommand(request.Id, request.AddressId, request.OrderDate, orderDetails);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);
    }

    [HttpPut("confirm")]
    public async Task<IActionResult> ConfirmOrder(ConfirmOrderRequest request, CancellationToken cancellationToken)
    {
        var command = new ConfirmOrderCommand(request.Id, request.ConfirmDate);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);
    }

    [HttpPut("cancel")]
    public async Task<IActionResult> CancelOrder(CancelOrderRequest request, CancellationToken cancellationToken)
    {
        var command = new CancelOrderCommand(request.Id, request.CancelDate);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);
    }
}
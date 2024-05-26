using AlbaPizzaApp.Application.Exceptions;
using AlbaPizzaApp.Application.OrderDetails.GetOrderDetailByOrder;
using AlbaPizzaApp.Application.OrderDetails.RegisterOrderDetail;
using AlbaPizzaApp.Application.OrderDetails.RemoveOrderDetail;
using AlbaPizzaApp.Application.OrderDetails.UpdateOrderDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlbaPizzaApp.API.Controllers.OrderDetails;
[Route("api/orderdetails")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    private readonly ISender _sender;

    public OrderDetailsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("by-order/{orderId:guid}")]
    public async Task<IActionResult> GetOrderDetailsByOrderId(Guid orderId, CancellationToken cancellationToken)
    {
        var query = new GetOrderDetailsByOrderIdQuery(orderId);
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterOrderDetail(RegisterOrderDetailRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterOrderDetailCommand(request.OrderId, request.ProductId, request.TaxType, request.Quantity, request.UnitPrice);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : throw new ResultException(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateOrderDetailCommand(request.Id, request.OrderId, request.ProductId, request.TaxType, request.Quantity, request.UnitPrice);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveOrderDetail(Guid id, Guid orderId, CancellationToken cancellationToken)
    {
        var command = new RemoveOrderDetailCommand(id, orderId);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);
    }
}
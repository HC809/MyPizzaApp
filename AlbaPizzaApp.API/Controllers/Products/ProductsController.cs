using AlbaPizzaApp.Application.Exceptions;
using AlbaPizzaApp.Application.Products.GetProducts;
using AlbaPizzaApp.Application.Products.RegisterProduct;
using AlbaPizzaApp.Application.Products.RemoveProduct;
using AlbaPizzaApp.Application.Products.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlbaPizzaApp.API.Controllers.Products;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        var query = new GetProductsQuery();
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterProduct(RegisterProductRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterProductCommand(request.Description, request.Price, request.TaxType);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : throw new ResultException(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateProductCommand(request.Id, request.Description, request.Price, request.TaxType);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveProduct(Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveProductCommand(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);

    }
}

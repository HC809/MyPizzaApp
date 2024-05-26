using AlbaPizzaApp.Application.Customers.GetCustomer;
using AlbaPizzaApp.Application.Customers.GetCustomers;
using AlbaPizzaApp.Application.Customers.RegisterCustomer;
using AlbaPizzaApp.Application.Customers.RemoveCustomer;
using AlbaPizzaApp.Application.Customers.UpdateCustomer;
using AlbaPizzaApp.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlbaPizzaApp.API.Controllers.Customers;

[Route("api/customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ISender _sender;

    public CustomersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
    {
        var query = new GetCustomersQuery();
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCustomerById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCustomerByIdQuery(id);
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterCustomer(RegisterCustomerRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterCustomerCommand(request.Name, request.Email, request.Phone);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : throw new ResultException(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateCustomerCommand(request.Id, request.Name, request.Email, request.Phone);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveCustomer(Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveCustomerCommand(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);
    }
}

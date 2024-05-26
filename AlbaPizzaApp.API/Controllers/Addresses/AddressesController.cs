using AlbaPizzaApp.Application.Addresses.GetAddress;
using AlbaPizzaApp.Application.Addresses.GetAddressByCustomer;
using AlbaPizzaApp.Application.Addresses.GetAddresses;
using AlbaPizzaApp.Application.Addresses.RegisterAddress;
using AlbaPizzaApp.Application.Addresses.RemoveAddress;
using AlbaPizzaApp.Application.Addresses.UpdateAddress;
using AlbaPizzaApp.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlbaPizzaApp.API.Controllers.Addresses;
[Route("api/addresses")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly ISender _sender;

    public AddressesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAddresses(CancellationToken cancellationToken)
    {
        var query = new GetAddressesQuery();
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAddressById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetAddressByIdQuery(id);
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("by-customer/{customerId:guid}")]
    public async Task<IActionResult> GetAddressesByCustomerId(Guid customerId, CancellationToken cancellationToken)
    {
        var query = new GetAddressesByCustomerIdQuery(customerId);
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAddress(RegisterAddressRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterAddressCommand(request.CustomerId, request.Country, request.State, request.City, request.Street, request.ZipCode);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : throw new ResultException(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAddress(UpdateAddressRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateAddressCommand(request.Id, request.Street, request.City, request.State, request.ZipCode, request.Country);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveAddress(Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveAddressCommand(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : throw new ResultException(result.Error);
    }
}

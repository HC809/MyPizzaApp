using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Addresses.UpdateAddress;
public sealed record UpdateAddressCommand(
    Guid Id,
    string Country,
    string State,
    string City,
    string Street,
    string ZipCode) : ICommand;


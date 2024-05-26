using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Addresses.RegisterAddress;
public sealed record RegisterAddressCommand(
    Guid CustomerId,
    string Country,
    string State,
    string City,
    string Street,
    string ZipCode) : ICommand<Guid>;

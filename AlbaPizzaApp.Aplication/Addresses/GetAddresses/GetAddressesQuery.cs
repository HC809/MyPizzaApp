using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Addresses.GetAddresses;
public sealed record GetAddressesQuery() : IQuery<IEnumerable<AddressResponse>>;


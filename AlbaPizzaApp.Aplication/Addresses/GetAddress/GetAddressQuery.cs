using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Addresses.GetAddress;
public sealed record GetAddressByIdQuery(Guid AddressId) : IQuery<AddressResponse>;


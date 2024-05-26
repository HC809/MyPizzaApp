using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Addresses.GetAddressByCustomer;
public sealed record GetAddressesByCustomerIdQuery(Guid CustomerId) : IQuery<IEnumerable<AddressResponse>>;


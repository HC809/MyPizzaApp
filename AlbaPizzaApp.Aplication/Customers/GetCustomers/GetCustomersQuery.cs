using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Customers.GetCustomers;
public sealed record GetCustomersQuery() : IQuery<IEnumerable<CustomerResponse>>;


using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Customers.GetCustomer;
public sealed record GetCustomerByIdQuery(Guid CustomerId) : IQuery<CustomerResponse>;


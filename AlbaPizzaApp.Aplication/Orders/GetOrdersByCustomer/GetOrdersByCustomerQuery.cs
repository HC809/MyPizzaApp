using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Orders.GetOrdersByCustomer;
public sealed record GetOrdersByCustomerIdQuery(Guid CustomerId) : IQuery<IEnumerable<OrderResponse>>;


using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Orders.GetOrders;
public sealed record GetOrdersQuery() : IQuery<IEnumerable<OrderResponse>>;

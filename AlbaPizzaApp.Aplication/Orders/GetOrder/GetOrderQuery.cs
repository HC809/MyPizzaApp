using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Orders.GetOrder;
public sealed record GetOrderByIdQuery(Guid OrderId) : IQuery<OrderResponse>;


using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.OrderDetails.GetOrderDetailByOrder;
public sealed record GetOrderDetailsByOrderIdQuery(Guid OrderId) : IQuery<IEnumerable<OrderDetailResponse>>;


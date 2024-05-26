using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Application.Orders.RegisterOrder;

namespace AlbaPizzaApp.Application.Orders.UpdateOrder;
public sealed record UpdateOrderCommand(
    Guid Id,
    Guid AddressId,
    DateTime OrderDate,
    IEnumerable<OrderDetailCommand> OrderDetails) : ICommand;


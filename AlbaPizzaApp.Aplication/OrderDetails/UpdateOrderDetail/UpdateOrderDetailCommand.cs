using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.OrderDetails.UpdateOrderDetail;
public sealed record UpdateOrderDetailCommand(
    Guid Id,
    Guid OrderId,
    Guid ProductId,
    string TaxType,
    int Quantity,
    decimal UnitPrice) : ICommand;


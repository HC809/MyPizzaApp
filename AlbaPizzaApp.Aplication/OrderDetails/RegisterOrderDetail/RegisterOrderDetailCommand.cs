using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Products;

namespace AlbaPizzaApp.Application.OrderDetails.RegisterOrderDetail;
public sealed record RegisterOrderDetailCommand(
    Guid OrderId,
    Guid ProductId,
    string TaxType,
    int Quantity,
    decimal UnitPrice) : ICommand<Guid>;


using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Products;

namespace AlbaPizzaApp.Application.Orders.RegisterOrder;
public sealed record RegisterOrderCommand(
    Guid CustomerId,
    Guid AddressId,
    DateTime OrderDate,
    IEnumerable<OrderDetailCommand> OrderDetails) : ICommand<Guid>;

public sealed record OrderDetailCommand(
    Guid ProductId,
    ProductTaxType TaxType,
    int Quantity,
    decimal UnitPrice);


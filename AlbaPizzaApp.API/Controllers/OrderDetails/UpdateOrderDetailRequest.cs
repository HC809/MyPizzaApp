using AlbaPizzaApp.Domain.Products;

namespace AlbaPizzaApp.API.Controllers.OrderDetails;

public sealed record UpdateOrderDetailRequest(
    Guid Id,
    Guid OrderId,
    Guid ProductId,
    string TaxType,
    int Quantity,
    decimal UnitPrice);


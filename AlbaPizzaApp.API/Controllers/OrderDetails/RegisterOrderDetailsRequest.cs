using AlbaPizzaApp.Domain.Products;

namespace AlbaPizzaApp.API.Controllers.OrderDetails;

public record RegisterOrderDetailRequest(
    Guid OrderId,
    Guid ProductId,
    string TaxType,
    int Quantity,
    decimal UnitPrice);

using AlbaPizzaApp.Domain.Products;

namespace AlbaPizzaApp.API.Controllers.Orders;

public record RegisterOrderRequest(
    Guid CustomerId,
    Guid AddressId,
    DateTime OrderDate,
    IEnumerable<OrderDetailRequest> OrderDetails);

public record OrderDetailRequest(
    Guid ProductId,
    ProductTaxType TaxType,
    int Quantity,
    decimal UnitPrice);


namespace AlbaPizzaApp.API.Controllers.Orders;

public sealed record UpdateOrderRequest(
    Guid Id,
    Guid AddressId,
    DateTime OrderDate,
    IEnumerable<OrderDetailRequest> OrderDetails);


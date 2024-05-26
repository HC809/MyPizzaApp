namespace AlbaPizzaApp.API.Controllers.Orders;

public sealed record CancelOrderRequest(
    Guid Id,
    DateTime CancelDate);


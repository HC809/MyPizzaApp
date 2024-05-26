namespace AlbaPizzaApp.API.Controllers.Orders;

public sealed record ConfirmOrderRequest(
    Guid Id,
    DateTime ConfirmDate);

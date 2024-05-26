namespace AlbaPizzaApp.API.Controllers.Customers;

public sealed record UpdateCustomerRequest(
    Guid Id,
    string Name,
    string Email,
    string Phone);

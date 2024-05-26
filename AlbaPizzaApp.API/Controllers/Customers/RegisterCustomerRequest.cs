namespace AlbaPizzaApp.API.Controllers.Customers;

public record RegisterCustomerRequest(
    string Name,
    string Email,
    string Phone);


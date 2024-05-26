namespace AlbaPizzaApp.API.Controllers.Addresses;

public record RegisterAddressRequest(
    Guid CustomerId,
    string Country,
    string State,
    string City,
    string Street,
    string ZipCode);


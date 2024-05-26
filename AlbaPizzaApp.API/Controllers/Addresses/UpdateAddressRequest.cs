namespace AlbaPizzaApp.API.Controllers.Addresses;

public sealed record UpdateAddressRequest(
    Guid Id,
    string Country,
    string State,
    string City,
    string Street,
    string ZipCode);


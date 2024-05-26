namespace AlbaPizzaApp.Application;
public sealed class AddressResponse
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public string Street { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
    public string ZipCode { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
}


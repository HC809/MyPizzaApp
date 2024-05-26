using AlbaPizzaApp.Domain.Abstractions;

namespace AlbaPizzaApp.Domain.Addresses;
public sealed class Address : Entity
{
    private Address(Guid id, Guid customerId, string country, string state, string city, string street, string zipCode) : base(id)
    {
        CustomerId = customerId;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
    }

    public string Country { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string ZipCode { get; private set; }
    public Guid CustomerId { get; private set; }

    public static Address Create(Guid customerId, string country, string state, string city, string street, string zipCode)
    {
        return new Address(Guid.NewGuid(), customerId, country, state, city, street, zipCode);
    }

    public void Update(string country, string state, string city, string street, string zipCode)
    {
        Country = country;
        State = state;
        City = city;
        Street = street;
        ZipCode = zipCode;
    }
}


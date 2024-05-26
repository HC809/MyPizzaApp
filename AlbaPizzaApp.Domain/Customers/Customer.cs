using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Addresses;

namespace AlbaPizzaApp.Domain.Customers;
public sealed class Customer : Entity
{
    private Customer(Guid id, string name, string email, string phone) : base(id)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public static Customer Create(string name, string email, string phone)
    {
        return new Customer(Guid.NewGuid(), name, email, phone);
    }

    public void Update(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
}
using AlbaPizzaApp.Domain.Abstractions;

namespace AlbaPizzaApp.Domain.Customers;
public static class CustomerErrors
{
    public static readonly Error NotFound = new("Customer.NotFound", "No existe un cliente con la ID proporcionado.");
    public static readonly Error ExistsEmail = new("Customer.ExistsEmail", "Ya existe un cliente con el correo electrónico proporcionado.");
    public static readonly Error ExistsPhone = new("Customer.ExistsPhone", "Ya existe un cliente con el número de teléfono proporcionado.");
}

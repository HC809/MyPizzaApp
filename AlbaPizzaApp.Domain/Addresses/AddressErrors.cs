
using AlbaPizzaApp.Domain.Abstractions;

namespace AlbaPizzaApp.Domain.Addresses;

public static class AddressErrors
{
    public static readonly Error NotFound = new("Address.NotFound", "No existe una dirección con la ID proporcionado.");
}

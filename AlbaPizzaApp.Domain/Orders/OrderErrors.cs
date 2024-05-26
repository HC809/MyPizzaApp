using AlbaPizzaApp.Domain.Abstractions;

namespace AlbaPizzaApp.Domain.Orders;
public static class OrderErrors
{
    public static readonly Error NotFound = new("Order.Found", "No existe una orden con el ID proporcionado.");
    public static readonly Error NotPending = new("Order.NotPending", "La orden no esta pendiente, por lo tanto no se puede confirmar.");
    public static readonly Error AlreadyCanceled = new("Order.AlreadyCanceled", "La orden ya fue canceloada previamente por otro usuario.");
}

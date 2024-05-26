using AlbaPizzaApp.Domain.Abstractions;

namespace AlbaPizzaApp.Domain.OrderDetails;

public static class OrderDetailErrors
{
    public static readonly Error NotFound = new("OrderDetail.NotFound", "No existe un detalle de orden con el ID proporcionado.");
    public static readonly Error NotPendingToRegister = new("OrderDetail.NotPendingToRegister", "La orden no esta pendiente, por lo tanto no se pueden agregar detalles.");
    public static readonly Error NotPendingToUpdate = new("OrderDetail.NotPendingToUpdate", "La orden no esta pendiente, por lo tanto no se pueden actualizar detalles.");
    public static readonly Error NotPendingToDelete = new("OrderDetail.NotPendingToDelete", "La orden no esta pendiente, por lo tanto no se eliminar actualizar detalles.");
}
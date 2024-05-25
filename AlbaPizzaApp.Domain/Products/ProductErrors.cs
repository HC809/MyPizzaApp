using AlbaPizza.Domain.Abstractions;

namespace AlbaPizza.Domain.Products;
public static class ProductErrors
{
    public static readonly Error ExistsDescription = new("Product.ExistsDescription", "Ya existe un producto con la descripción proporcionada.");
    public static readonly Error NotFound = new("Product.NotFound", "No existe un producto con la ID proporcionado.");
}

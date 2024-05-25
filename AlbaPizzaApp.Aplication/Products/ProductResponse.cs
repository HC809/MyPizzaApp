namespace AlbaPizzaApp.Application.Products;
public sealed class ProductResponse
{
    public Guid Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public string TaxType { get; init; } = string.Empty;
}


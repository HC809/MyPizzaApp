namespace AlbaPizzaApp.Application.OrderDetails;
public sealed class OrderDetailResponse
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public string TaxType { get; init; } = string.Empty;
    public decimal PriceWithoutTax { get; init; }
    public decimal TaxAmount { get; init; }
    public decimal PriceWithTax { get; init; }
}


namespace AlbaPizzaApp.Application.Orders;
public sealed class OrderResponse
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public DateTime OrderDate { get; init; }
    public decimal Subtotal { get; init; }
    public decimal TaxAmount { get; init; }
    public decimal TotalAmount { get; init; }
    public string Status { get; init; } = string.Empty;
    public DateTime? ConfirmDate { get; init; }
    public DateTime? CancelDate { get; init; }
}


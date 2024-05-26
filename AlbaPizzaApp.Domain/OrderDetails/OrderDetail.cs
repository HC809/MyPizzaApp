using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Products;

namespace AlbaPizzaApp.Domain.OrderDetails;
public sealed class OrderDetail : Entity
{
    private OrderDetail(Guid id, Guid orderId, Guid productId, ProductTaxType taxType, int quantity, decimal unitPrice) : base(id)
    {
        OrderId = orderId;
        ProductId = productId;
        TaxType = taxType;
        Quantity = quantity;
        UnitPrice = unitPrice;
        CalculatePrices();
    }

    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public ProductTaxType TaxType { get; private set; }
    public decimal PriceWithoutTax { get; private set; }
    public decimal TaxAmount { get; private set; }
    public decimal PriceWithTax { get; private set; }

    public static OrderDetail Create(Guid orderId, Guid productId, ProductTaxType taxType, int quantity, decimal unitPrice)
    {
        return new OrderDetail(Guid.NewGuid(), orderId, productId, taxType, quantity, unitPrice);
    }

    public void Update(int quantity, decimal unitPrice, ProductTaxType taxType)
    {
        Quantity = quantity;
        UnitPrice = unitPrice;
        TaxType = taxType;
        CalculatePrices();
    }

    private void CalculatePrices()
    {
        decimal taxMultiplier = (decimal)TaxType / 100;
        PriceWithoutTax = UnitPrice * Quantity;
        TaxAmount = PriceWithoutTax * taxMultiplier;
        PriceWithTax = PriceWithoutTax + TaxAmount;
    }
}



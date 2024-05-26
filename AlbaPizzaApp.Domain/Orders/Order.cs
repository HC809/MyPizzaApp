using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.OrderDetails;

namespace AlbaPizzaApp.Domain.Orders;
public sealed class Order : Entity
{
    private Order(Guid id, Guid customerId, DateTime orderDate) : base(id)
    {
        CustomerId = customerId;
        OrderDate = orderDate;
        OrderDetails = new List<OrderDetail>();
        Status = OrderStatus.Pending;
    }

    public Guid CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public decimal Subtotal { get; private set; }
    public decimal TaxAmount { get; private set; }
    public decimal TotalAmount { get; private set; }
    public OrderStatus Status { get; private set; }
    public ICollection<OrderDetail> OrderDetails { get; private set; }

    public static Order Create(Guid customerId, DateTime orderDate)
    {
        return new Order(Guid.NewGuid(), customerId, orderDate);
    }

    public void AddOrderDetail(OrderDetail orderDetail)
    {
        OrderDetails.Add(orderDetail);
        CalculateAmounts();
    }

    private void CalculateAmounts()
    {
        Subtotal = OrderDetails.Sum(od => od.PriceWithoutTax);
        TaxAmount = OrderDetails.Sum(od => od.TaxAmount);
        TotalAmount = OrderDetails.Sum(od => od.PriceWithTax);
    }

    public Result Confirm()
    {
        if (Status != OrderStatus.Pending)
            return Result.Failure(OrderErrors.NotPending);

        Status = OrderStatus.Confirmed;

        return Result.Success();
    }

    public Result Cancel()
    {
        if (Status == OrderStatus.Cancelled)
            return Result.Failure(OrderErrors.AlreadyCanceled);

        Status = OrderStatus.Cancelled;

        return Result.Success();
    }
}



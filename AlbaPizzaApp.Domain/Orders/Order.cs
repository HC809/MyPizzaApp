using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.OrderDetails;

namespace AlbaPizzaApp.Domain.Orders;
public sealed class Order : Entity
{
    private Order(Guid id, Guid customerId, Guid addressId, DateTime orderDate) : base(id)
    {
        CustomerId = customerId;
        AddressId = addressId;
        OrderDate = orderDate;
        OrderDetails = new List<OrderDetail>();
        Status = OrderStatus.Pending;
    }

    public Guid CustomerId { get; private set; }
    public Guid AddressId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public decimal Subtotal { get; private set; }
    public decimal TaxAmount { get; private set; }
    public decimal TotalAmount { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime ConfirmDate { get; private set; }
    public DateTime CancelDate { get; private set; }
    public ICollection<OrderDetail> OrderDetails { get; private set; }

    public static Order Create(Guid customerId, Guid addressId, DateTime orderDate)
    {
        return new Order(Guid.NewGuid(), customerId, addressId, orderDate);
    }

    public Result Update(DateTime orderDate, Guid addressId, ICollection<OrderDetail> orderDetails)
    {
        if (Status != OrderStatus.Pending)
            return Result.Failure(OrderErrors.NotPendingToUpdate);

        OrderDate = orderDate;
        AddressId = addressId;
        OrderDetails = orderDetails;
        CalculateAmounts();

        return Result.Success();
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

    public Result Confirm(DateTime date)
    {
        if (Status != OrderStatus.Pending)
            return Result.Failure(OrderErrors.NotPending);

        Status = OrderStatus.Confirmed;
        ConfirmDate = date;

        return Result.Success();
    }

    public Result Cancel(DateTime date)
    {
        if (Status == OrderStatus.Cancelled)
            return Result.Failure(OrderErrors.AlreadyCanceled);

        Status = OrderStatus.Cancelled;
        CancelDate = date;

        return Result.Success();
    }
}



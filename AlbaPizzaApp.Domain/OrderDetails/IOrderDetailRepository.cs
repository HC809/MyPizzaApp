namespace AlbaPizzaApp.Domain.OrderDetails;
public interface IOrderDetailRepository
{
    Task<OrderDetail?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(OrderDetail product);
    void Update(OrderDetail product);
    void Remove(OrderDetail product);
}

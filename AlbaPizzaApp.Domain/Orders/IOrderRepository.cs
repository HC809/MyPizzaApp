namespace AlbaPizzaApp.Domain.Orders;
public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Order product);
    void Update(Order product);
    void Remove(Order product);
}

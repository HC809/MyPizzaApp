using AlbaPizzaApp.Domain.Orders;

namespace AlbaPizzaApp.Infraestructure.Repositories;
internal sealed class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
